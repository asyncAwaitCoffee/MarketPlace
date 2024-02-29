using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.FormsUI;
using MarketPlaceUI.Supporting;
using System.Diagnostics;
using System.Windows.Forms;

namespace MarketPlaceUI
{
    public partial class MarketPlaceForm : Form
    {
        private CurrentForm _currentForm;
        public MarketPlaceForm()
        {
            InitializeComponent();
            TryLoggedInAsSaved();

            this.Load += (object sender, EventArgs e) => buttonMenuMain.PerformClick();
        }

        private async void TryLoggedInAsSaved()
        {
            if (File.Exists("./stay_logged_in.txt"))
            {
                // TODO - better checkBoxStayLoggedIn auth
                string[] userData = await File.ReadAllLinesAsync("./stay_logged_in.txt");

                string userLogin = userData[1];

                if (int.TryParse(userData[0], out int userId) && int.TryParse(userData[2], out int userLevel))
                {
                    decimal balance = await DataAccess.GetUserBalance(userId);
                    User.Init(userId, userLogin, userLevel, balance);
                    // TODO - method for labels
                    labelLogin.Text = userLogin;
                    labelBalance.Text = $"{balance}$";
                    labelBalance.Left = labelBalance.Parent.Width / 2 - labelBalance.Width / 2;
                    labelLogin.Left = labelBalance.Parent.Width / 2 - labelLogin.Width / 2;
                }
            }
        }

        private void buttonMenuMain_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(_currentForm.ToString());
            if (_currentForm == CurrentForm.Main)
            {
                return;
            }
            _currentForm = CurrentForm.Main;
            flowLayoutPanelHeaderControls.Controls.Clear();

            panelContent.Controls.Clear();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            Image image = Image.FromFile(@"D:\Programming\projects\MarketPlace\Assets\auction.png");

            pictureBox.Image = new Bitmap(image, new Size(200, 200));

            image.Dispose();

            panelContent.Controls.Add(pictureBox);

        }

        private async void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (!LoggingInRequired())
            {
                return;
            }

            // TODO - scrollbar issue
            if (_currentForm == CurrentForm.Browse)
            {
                return;
            }
            _currentForm = CurrentForm.Browse;
            // Header controls remove
            flowLayoutPanelHeaderControls.Controls.Clear();

            // Header controls add

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
                int? byDate = comboBoxByDate.SelectedIndex == -1 ? null : comboBoxByDate.SelectedIndex;
                int? byPrice = comboBoxByPrice.SelectedIndex == -1 ? null : comboBoxByPrice.SelectedIndex;
                bool onlyFav = checkBoxFav.Checked;
                // TODO - pageNo
                List<MarketItem> marketItemsOrdered = await DataAccess.GetMarketItems(1, 20, User.Instance().Id, orderByPrice: byPrice, orderByDate: byDate, onlyFav: onlyFav);

// TODO - uncomment                //FlowLayoutPanel panelContainer = BuildMarketItemsLayout(marketItemsOrdered);
                panelContent.Controls.Clear();

                // TODO - uncomment                panelContent.Controls.Add(panelContainer);
            };

            flowLayoutPanelHeaderControls.Controls.Add(buttonOrder);
            flowLayoutPanelHeaderControls.Controls.Add(labelByDate);
            flowLayoutPanelHeaderControls.Controls.Add(comboBoxByDate);
            flowLayoutPanelHeaderControls.Controls.Add(labelByPrice);
            flowLayoutPanelHeaderControls.Controls.Add(comboBoxByPrice);
            flowLayoutPanelHeaderControls.Controls.Add(checkBoxFav);

            foreach (Control control in panelContent.Controls)
            {
                control.Dispose();
            }
            panelContent.Controls.Clear();


            // TODO - pageNo
            List<MarketItem> marketItems = await DataAccess.GetMarketItems(1, 20, User.Instance().Id);

            FlowLayoutPanel panelAllItemsContainer = new FlowLayoutPanel();

            panelAllItemsContainer.Location = new Point(0, 0);
            panelAllItemsContainer.Dock = DockStyle.Fill;
            panelAllItemsContainer.Visible = true;
            panelAllItemsContainer.AutoScroll = true;
            panelAllItemsContainer.AutoSize = true;
            panelAllItemsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            foreach (var item in marketItems)
            {
                panelAllItemsContainer.Controls.Add(BuildItemContainer(item));
            }

            panelContent.Controls.Add(panelAllItemsContainer);


            TableLayoutPanel BuildItemContainer(MarketItem marketItem)
            {
                TableLayoutPanel itemContainer = BrowseItemFactory.BuildItemContainer();

                PictureBox itemPictureBox = BrowseItemFactory.buildItemPictureBox(marketItem);                
                Task.Run(() => { itemPictureBox.Image = LoadImageAsync(marketItem.Id).Result; }); // TODO - revise ??

                TextBox itemTextBox = BrowseItemFactory.BuildItemDescriptionBox(marketItem);

                TableLayoutPanel itemControlsContainer = BrowseItemFactory.BuildItemControlsContainer();

                FlowLayoutPanel itemButtonsGroupLeft = BrowseItemFactory.BuildItemButtonsContainer();
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

                FlowLayoutPanel itemButtonsGroupRight = BrowseItemFactory.BuildItemButtonsContainer(FlowDirection.RightToLeft);
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
        }

        private async void buttonMyItems_Click(object sender, EventArgs e)
        {
            if (!LoggingInRequired())
            {
                return;
            }

            if (_currentForm == CurrentForm.MyItems)
            {
                return;
            }
            _currentForm = CurrentForm.MyItems;
            flowLayoutPanelHeaderControls.Controls.Clear();

            panelContent.Controls.Clear();

            DataGridView dataGridView = new DataGridView();
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn columnTitle = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnCategory = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnPriceStart = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnPriceCurrent = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnPriceEnd = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnBidStep = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnDateStart = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnDateEnd = new DataGridViewTextBoxColumn();
            // TODO - edit
            //DataGridViewButtonColumn columnEditButton = new DataGridViewButtonColumn();

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView.Columns.AddRange([
                columnTitle, columnCategory, columnPriceStart, columnPriceCurrent, columnPriceEnd,
                columnBidStep, columnDateStart, columnDateEnd//, columnEditButton
                ]);


            columnTitle.HeaderText = "Title";
            columnTitle.Name = "columnTitle";

            columnCategory.HeaderText = "Category";
            columnCategory.Name = "columnCategory";

            columnPriceStart.HeaderText = "Start Price";
            columnPriceStart.Name = "columnPriceStart";

            columnPriceCurrent.HeaderText = "Current Price";
            columnPriceCurrent.Name = "columnPriceCurrent";

            columnPriceEnd.HeaderText = "End Price";
            columnPriceEnd.Name = "columnPriceEnd";

            columnBidStep.HeaderText = "Bid Step";
            columnBidStep.Name = "columnBidStep";

            columnDateStart.HeaderText = "Start Date";
            columnDateStart.Name = "columnDateStart";

            columnDateEnd.HeaderText = "End Date";
            columnDateEnd.Name = "columnDateEnd";


            //columnEditButton.HeaderText = "Edit";
            //columnEditButton.Name = "columnEditButton";

            List<MarketItem> myMarketItems = await DataAccess.GetMarketItems(1, 20, User.Instance().Id, filterByOwnerId: true);

            foreach (var myItem in myMarketItems)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView);


                row.Tag = myItem.Id;

                row.Cells[0].Value = myItem.Title;
                row.Cells[1].Value = myItem.Category;
                row.Cells[2].Value = myItem.PriceStart;
                row.Cells[3].Value = myItem.PriceCurrent;
                row.Cells[4].Value = myItem.PriceEnd;
                row.Cells[5].Value = myItem.BidStep;
                row.Cells[6].Value = myItem.DateStart;
                row.Cells[7].Value = myItem.DateEnd;
                //row.Cells[8].Value = "Edit";

                dataGridView.Rows.Add(row);
            }

            panelContent.Controls.Add(dataGridView);

            Button addItemButton = ButtonFactory.BuildButton("addItemButton", ButtonSize.Small, new Point(60, 0), text: "Add");

            addItemButton.Click += addItemButton_Click;

            flowLayoutPanelHeaderControls.Controls.Add(addItemButton);

            void addItemButton_Click(object sender, EventArgs e)
            {
                ItemSaleForm itemAddForm = new ItemSaleForm();
                itemAddForm.ShowDialog();
            }
        }

        private async void buttonHistory_Click(object sender, EventArgs e)
        {
            if (!LoggingInRequired())
            {
                return;
            }

            if (_currentForm == CurrentForm.History)
            {
                return;
            }
            _currentForm = CurrentForm.History;
            flowLayoutPanelHeaderControls.Controls.Clear();

            panelContent.Controls.Clear();

            DataGridView dataGridView = new DataGridView();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn columnItem = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnOperation = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnPartner = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnEmail = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnDate = new DataGridViewTextBoxColumn();

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView.Columns.AddRange([
                columnItem, columnOperation, columnPartner, columnEmail, columnDate
                ]);
            dataGridView.Name = "dataGridView1";

            columnItem.HeaderText = "Item";
            columnItem.Name = "columnItem";
            columnOperation.HeaderText = "Operation";
            columnOperation.Name = "columnOperation";
            columnPartner.HeaderText = "Partner";
            columnPartner.Name = "columnPartner";
            columnEmail.HeaderText = "Email";
            columnEmail.Name = "columnEmail";
            columnDate.HeaderText = "Date";
            columnDate.Name = "columnDate";

            List<HistoryItem> myHistoryItems = await DataAccess.GetHsitory(User.Instance().Id);

            foreach (var myHistoryItem in myHistoryItems)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView);

                // TODO - also check if operation is Buy or Sell - Place doesnt need color
                switch (myHistoryItem.OrderState)
                {
                    case 0:
                        break;
                    case 1:
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.Green;
                        break;
                }

                string operationString = Enum.GetName(typeof(OperationType), myHistoryItem.OperationType);

                row.Cells[0].Value = myHistoryItem.Title;
                row.Cells[1].Value = operationString;
                row.Cells[2].Value = myHistoryItem.PersonName;
                row.Cells[3].Value = myHistoryItem.Email;
                row.Cells[4].Value = myHistoryItem.HistoryDate;

                dataGridView.Rows.Add(row);
            }

            panelContent.Controls.Add(dataGridView);
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm(labelLogin, labelBalance);
            DialogResult dialogResult = authForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                buttonMenuMain.PerformClick();
            }
        }



        // TODO - for all controls?
        private async Task<Image> LoadImageAsync(int itemId)
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

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            if (!LoggingInRequired())
            {
                return;
            }
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        private bool LoggingInRequired()
        {
            if (!User.isLoggedIn)
            {
                AuthForm authForm = new AuthForm(labelLogin, labelBalance);
                authForm.ShowDialog();
            }

            return User.isLoggedIn;
        }

        private void buttonMails_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm();
            emailForm.ShowDialog();
        }
    }
}
