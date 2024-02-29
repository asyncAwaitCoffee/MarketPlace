using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.Supporting;
using System.Diagnostics;
using System.Security.Policy;

namespace MarketPlaceUI.FormsUI
{
    internal static class BrowseItemFactory
    {
        public static TableLayoutPanel BuildItemContainer(MarketItem marketItem)
        {
            TableLayoutPanel itemContainer = BuildItemContainer();

            PictureBox itemPictureBox = buildItemPictureBox(marketItem);
            Task.Run(() => { itemPictureBox.Image = LoadImageAsync(marketItem.Id).Result; }); // TODO - revise ??

            TextBox itemTextBox = BuildItemDescriptionBox(marketItem);

            TableLayoutPanel itemControlsContainer = BuildItemControlsContainer();

            FlowLayoutPanel itemButtonsGroupLeft = BuildItemButtonsContainer();
            Button buttonInfo = ButtonFactory.BuildButton("buttonInfo", ButtonSize.Tiny, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\question.png");
            buttonInfo.Click += (object sender, EventArgs e) => {
                ItemInfoForm itemInfoForm = new ItemInfoForm(); itemInfoForm.ShowDialog();
            };

            string star = marketItem.IsFav ? "star.png" : "star_no.png";
            Button buttonFav = ButtonFactory.BuildButton("buttonFav", ButtonSize.Tiny, new Point(0, 0), imagePath: @$"D:\Programming\projects\MarketPlace\Assets\{star}");
            buttonFav.Click += async (object sender, EventArgs e) =>
            {
                await DataAccess.ToggleItemFavorite(User.Instance().Id, marketItem.Id);
            };

            itemButtonsGroupLeft.Controls.AddRange([buttonInfo, buttonFav]);

            FlowLayoutPanel itemButtonsGroupRight = BuildItemButtonsContainer(FlowDirection.RightToLeft);
            Button buttonBuy = ButtonFactory.BuildButton("buttonBuy", ButtonSize.Small, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\salary.png");
            buttonBuy.Click += async (object sender, EventArgs e) =>
            {
                var result = MessageBox.Show($"Confirm your purchase of {marketItem.Title} for {marketItem.PriceStart}$.",
                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    int orderId = await DataAccess.AddItemToOrder(User.Instance().Id, marketItem.Id);

                    FormMethods.RemoveControlByGrandChild(itemContainer);

                    await DataAccess.SaveHistory(User.Instance().Id, marketItem.OwnerId, marketItem.Id, (int)OperationType.Buy, marketItem.PriceEnd);
                    await DataAccess.SaveHistory(marketItem.OwnerId, User.Instance().Id, marketItem.Id, (int)OperationType.Buy, marketItem.PriceEnd);

                    MessageBox.Show($"Order #{orderId} registered.");
                }
            };

            itemButtonsGroupRight.Controls.Add(buttonBuy);


            if (marketItem.BidStep != 0)
            {
                Button buttonBid = ButtonFactory.BuildButton("buttonBid", ButtonSize.Small, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\profits.png");

                buttonBid.Click += async (object sender, EventArgs e) =>
                {
                    var result = MessageBox.Show($"Confirm your bid of {Math.Round(marketItem.PriceCurrent + marketItem.BidStep, 2)}$ for {marketItem.Title}$.",
                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        int bidResult = await DataAccess.BidItem(User.Instance().Id, marketItem.Id);

                        switch (bidResult)
                        {
                            case 0:
                                // todo string possibleReason = "";
                                MessageBox.Show($"Unable to bid.");
                                break;
                            case 1:
                                MessageBox.Show("Bid is successful.");
                                FormMethods.RemoveControlByGrandChild(itemContainer);
                                break;
                            case 2:
                                MessageBox.Show($"Congratulations! You baught {marketItem.Title}");
                                break;
                            default:
                                MessageBox.Show($"Unhandled code: {bidResult}.");
                                break;
                        }

                        await DataAccess.SaveHistory(User.Instance().Id, marketItem.OwnerId, marketItem.Id, (int)OperationType.Bid, marketItem.PriceEnd);
                    }
                };

                itemButtonsGroupRight.Controls.Add(buttonBid);
            }

            itemControlsContainer.Controls.Add(itemButtonsGroupLeft, 0, 0);
            itemControlsContainer.Controls.Add(itemButtonsGroupRight, 1, 0);

            itemContainer.Controls.Add(itemPictureBox);
            itemContainer.Controls.Add(itemTextBox);
            itemContainer.Controls.Add(itemControlsContainer);

            return itemContainer;
        }
        public static Control[] BuildHeaderControls(Panel panelParentNode)
        {
            Label labelByDate = new Label();
            labelByDate.Text = "by date:";
            labelByDate.AutoSize = true;
            labelByDate.Margin = new Padding(5, 9, 0, 0);

            ComboBox comboBoxByDate = new ComboBox();
            comboBoxByDate.Items.Add("asc");
            comboBoxByDate.Items.Add("desc");
            comboBoxByDate.Width = 60;
            comboBoxByDate.Margin = new Padding(5, 6, 0, 0);
            comboBoxByDate.KeyPress += (object sender, KeyPressEventArgs e) => { e.Handled = true; };

            Label labelByPrice = new Label();
            labelByPrice.Text = "by price:";
            labelByPrice.AutoSize = true;
            labelByPrice.Margin = new Padding(5, 9, 0, 0);

            ComboBox comboBoxByPrice = new ComboBox();
            comboBoxByPrice.Items.Add("asc");
            comboBoxByPrice.Items.Add("desc");
            comboBoxByPrice.Width = 60;
            comboBoxByPrice.Margin = new Padding(5, 6, 0, 0);
            comboBoxByPrice.KeyPress += (object sender, KeyPressEventArgs e) => { e.Handled = true; };

            CheckBox checkBoxFav = new CheckBox();
            checkBoxFav.Text = "Favorite";
            checkBoxFav.Margin = new Padding(15, 9, 0, 0);

            Button buttonOrder = ButtonFactory.BuildButton("buttonOrder", ButtonSize.Small, new Point(5, 5), text: "Order");
            buttonOrder.Click += async (object sender, EventArgs e) =>
            {
                panelParentNode.Controls.Clear();

                int? byDate = comboBoxByDate.SelectedIndex == -1 ? null : comboBoxByDate.SelectedIndex;
                int? byPrice = comboBoxByPrice.SelectedIndex == -1 ? null : comboBoxByPrice.SelectedIndex;
                bool onlyFav = checkBoxFav.Checked;
                // TODO - pageNo
                List<MarketItem> marketItemsOrdered = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id, orderByPrice: byPrice, orderByDate: byDate, onlyFav: onlyFav);
                FlowLayoutPanel panelAllItemsContainer = BuildAllItemsContainer();
                foreach (var item in marketItemsOrdered)
                {
                    panelAllItemsContainer.Controls.Add(BuildItemContainer(item));
                }
                panelParentNode.Controls.Add(panelAllItemsContainer);
            };

            Button buttonPrev = ButtonFactory.BuildButton("buttonPrev", ButtonSize.Small, new Point(5, 5), text: "Prev");
            buttonPrev.Click += async (object sender, EventArgs e) =>
            {
                if (AppState.CurrentPage == 1)
                {
                    return;
                }

                // TODO - pause before loading images/data ??

                AppState.isLoadNext = true;

                panelParentNode.Controls.Clear();

                int? byDate = comboBoxByDate.SelectedIndex == -1 ? null : comboBoxByDate.SelectedIndex;
                int? byPrice = comboBoxByPrice.SelectedIndex == -1 ? null : comboBoxByPrice.SelectedIndex;
                bool onlyFav = checkBoxFav.Checked;

                AppState.CurrentPage = AppState.CurrentPage - 1;

                Debug.WriteLine($"AppState.CurrentPage: {AppState.CurrentPage}");

                List<MarketItem> marketItemsOrdered = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id, orderByPrice: byPrice, orderByDate: byDate, onlyFav: onlyFav);
                FlowLayoutPanel panelAllItemsContainer = BuildAllItemsContainer();
                foreach (var item in marketItemsOrdered)
                {
                    panelAllItemsContainer.Controls.Add(BuildItemContainer(item));
                }
                panelParentNode.Controls.Add(panelAllItemsContainer);
            };

            Button buttonNext = ButtonFactory.BuildButton("buttonNext", ButtonSize.Small, new Point(5, 5), text: "Next");
            buttonNext.Click += async (object sender, EventArgs e) =>
            {
                if (!AppState.isLoadNext)
                {
                    return;
                }

                int? byDate = comboBoxByDate.SelectedIndex == -1 ? null : comboBoxByDate.SelectedIndex;
                int? byPrice = comboBoxByPrice.SelectedIndex == -1 ? null : comboBoxByPrice.SelectedIndex;
                bool onlyFav = checkBoxFav.Checked;

                AppState.CurrentPage = AppState.CurrentPage + 1;

                List<MarketItem> marketItemsOrdered = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id, orderByPrice: byPrice, orderByDate: byDate, onlyFav: onlyFav);

                if (marketItemsOrdered.Count == 0)
                {
                    AppState.isLoadNext = false;
                    AppState.CurrentPage = AppState.CurrentPage - 1;
                    return;
                }

                // TODO - pause before loading images/data ??

                panelParentNode.Controls.Clear();

                FlowLayoutPanel panelAllItemsContainer = BuildAllItemsContainer();
                foreach (var item in marketItemsOrdered)
                {
                    panelAllItemsContainer.Controls.Add(BuildItemContainer(item));
                }
                panelParentNode.Controls.Add(panelAllItemsContainer);
            };

            ComboBox comboBoxItemsPerPage = new ComboBox();
            comboBoxItemsPerPage.Items.Add("3");
            comboBoxItemsPerPage.Items.Add("5");
            comboBoxItemsPerPage.Items.Add("10");
            comboBoxItemsPerPage.Width = 60;
            comboBoxItemsPerPage.Margin = new Padding(5, 6, 0, 0);
            comboBoxItemsPerPage.KeyPress += (object sender, KeyPressEventArgs e) => { e.Handled = true; };
            comboBoxItemsPerPage.SelectedItem = $"{AppState.ItemsPerPage}";
            comboBoxItemsPerPage.SelectedIndexChanged += async (object sender, EventArgs e) =>
            {
                AppState.ItemsPerPage = int.Parse((string)comboBoxItemsPerPage.SelectedItem);
                AppState.CurrentPage = 1;
                AppState.isLoadNext = true;

                panelParentNode.Controls.Clear();

                int? byDate = comboBoxByDate.SelectedIndex == -1 ? null : comboBoxByDate.SelectedIndex;
                int? byPrice = comboBoxByPrice.SelectedIndex == -1 ? null : comboBoxByPrice.SelectedIndex;
                bool onlyFav = checkBoxFav.Checked;

                List<MarketItem> marketItemsOrdered = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id, orderByPrice: byPrice, orderByDate: byDate, onlyFav: onlyFav);

                FlowLayoutPanel panelAllItemsContainer = BuildAllItemsContainer();
                foreach (var item in marketItemsOrdered)
                {
                    panelAllItemsContainer.Controls.Add(BuildItemContainer(item));
                }
                panelParentNode.Controls.Add(panelAllItemsContainer);
            };

            return [buttonOrder, labelByDate, comboBoxByDate, labelByPrice, comboBoxByPrice, checkBoxFav, buttonPrev, buttonNext, comboBoxItemsPerPage];
        }
        public static FlowLayoutPanel BuildAllItemsContainer()
        {
            FlowLayoutPanel panelAllItemsContainer = new FlowLayoutPanel();

            panelAllItemsContainer.Location = new Point(0, 0);
            panelAllItemsContainer.Dock = DockStyle.Fill;
            panelAllItemsContainer.Visible = true;
            panelAllItemsContainer.AutoScroll = true;
            panelAllItemsContainer.AutoSize = true;
            panelAllItemsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            return panelAllItemsContainer;
        }
        public static TableLayoutPanel BuildItemContainer()
        {
            TableLayoutPanel itemContainer = new TableLayoutPanel();
            itemContainer.Size = new Size(300, 300);
            itemContainer.ColumnCount = 1;
            itemContainer.RowCount = 3;
            itemContainer.BackColor = Color.Green;
            itemContainer.Margin = new Padding(3);
            itemContainer.Padding = new Padding(0);

            return itemContainer;
        }

        public static PictureBox buildItemPictureBox(MarketItem marketItem)
        {
            PictureBox itemPictureBox = new PictureBox();
            itemPictureBox.Size = new Size(300, 200);
            itemPictureBox.BackColor = Color.White;
            itemPictureBox.Margin = new Padding(0);
            itemPictureBox.Padding = new Padding(0);
            itemPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            Label labelTitle = new Label();
            labelTitle.BackColor = Color.White;
            labelTitle.Text = marketItem.Title;
            labelTitle.Top = 0;
            labelTitle.Left = 0;

            Label labelPrice = new Label();
            labelPrice.BackColor = Color.White;
            labelPrice.Text = $"{marketItem.PriceStart}$";
            labelPrice.Top = itemPictureBox.Height - labelTitle.Height;
            labelPrice.Left = itemPictureBox.Width - labelTitle.Width;

            itemPictureBox.Controls.Add(labelTitle);
            itemPictureBox.Controls.Add(labelPrice);

            return itemPictureBox;
        }

        public static TextBox BuildItemDescriptionBox(MarketItem marketItem)
        {
            TextBox itemTextBox = new TextBox();
            itemTextBox.Multiline = true;
            itemTextBox.Size = new Size(300, 60);
            itemTextBox.BorderStyle = BorderStyle.None;
            itemTextBox.Margin = new Padding(0);
            itemTextBox.Padding = new Padding(0);
            itemTextBox.Enabled = false;
            itemTextBox.Text = marketItem.Description;

            return itemTextBox;
        }

        public static TableLayoutPanel BuildItemControlsContainer()
        {
            TableLayoutPanel itemButtonsContainer = new TableLayoutPanel();
            itemButtonsContainer.ColumnCount = 2;
            itemButtonsContainer.RowCount = 1;
            itemButtonsContainer.Size = new Size(300, 40);
            itemButtonsContainer.Margin = new Padding(0);
            itemButtonsContainer.Padding = new Padding(0);

            return itemButtonsContainer;
        }

        public static FlowLayoutPanel BuildItemButtonsContainer(FlowDirection flowDirection = FlowDirection.LeftToRight)
        {
            FlowLayoutPanel ItemButtonsContainer = new FlowLayoutPanel();
            ItemButtonsContainer.Dock = DockStyle.Fill;
            ItemButtonsContainer.BackColor = UISettings.Colors[0];
            ItemButtonsContainer.Size = new Size(150, 50);
            ItemButtonsContainer.Margin = new Padding(0);
            ItemButtonsContainer.Padding = new Padding(0);
            ItemButtonsContainer.FlowDirection = flowDirection;

            return ItemButtonsContainer;
        }

        public static async Task<Image> LoadImageAsync(int itemId)
        {
            byte[] imageData = await DataAccess.RetrieveImageFromDatabase(itemId);

            TaskCompletionSource<Image> tcs = new TaskCompletionSource<Image>();

            if (imageData == null)
            {
                Image image = Image.FromFile(@"D:\Programming\projects\MarketPlace\Assets\NO_IMAGE.png");
                tcs.SetResult(image);
            }

            else
            {
                await Task.Run(() =>
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        tcs.SetResult(Image.FromStream(ms));
                    }
                });
            }

            return await tcs.Task;
        }
    }
}
