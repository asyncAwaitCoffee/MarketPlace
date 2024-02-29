using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.Supporting;

namespace MarketPlaceUI.FormsUI
{
    internal static class BrowseItemFactory
    {
        public static PictureBox BuildBrowseHeaderBox(MarketItem marketItem)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.White;
            pictureBox.Size = new Size(300, 200);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            Label labelTitle = new Label();
            labelTitle.BackColor = Color.White;
            labelTitle.Text = marketItem.Title;
            labelTitle.Top = 0;
            labelTitle.Left = 0;
            labelTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            Label labelPrice = new Label();
            labelPrice.BackColor = Color.White;
            labelPrice.Text = $"{marketItem.PriceStart}$";
            labelPrice.Top = pictureBox.Height - labelTitle.Height;
            labelPrice.Left = pictureBox.Width - labelTitle.Width;
            labelPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            pictureBox.Controls.Add(labelTitle);
            pictureBox.Controls.Add(labelPrice);

            return pictureBox;
        }

        public static TableLayoutPanel BuildBrowseFooterBox(MarketItem marketItem)
        {
            TableLayoutPanel panelInner = new TableLayoutPanel();
            panelInner.Size = new Size(300, 100);
            panelInner.Dock = DockStyle.Bottom;
            panelInner.ColumnCount = 1;
            panelInner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelInner.RowCount = 2;
            panelInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            panelInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            panelInner.Padding = new Padding(0);
            panelInner.Margin = new Padding(0);
            panelInner.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Location = new Point(0, 0);
            //textBox.ScrollBars = ScrollBars.Vertical;
            textBox.BackColor = Color.WhiteSmoke;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            //textBox.Size = new Size(300, 200);
            textBox.Margin = new Padding(0);
            textBox.Text = marketItem.Description;
            //textBox.ReadOnly = true;
            textBox.Enabled = false;

            Panel controlWrapperPanel = new Panel();
            controlWrapperPanel.Dock = DockStyle.Fill;
            controlWrapperPanel.Padding = new Padding(0);
            controlWrapperPanel.Margin = new Padding(0);
            controlWrapperPanel.BackColor = UISettings.Colors[0];

            FlowLayoutPanel panelControlsLeft = new FlowLayoutPanel();
            //panelControlsLeft.Dock = DockStyle.Left;
            panelControlsLeft.Size = new Size(150, 40);
            panelControlsLeft.Padding = new Padding(0);
            panelControlsLeft.Margin = new Padding(0);
            panelControlsLeft.FlowDirection = FlowDirection.LeftToRight;

            Button buttonInfo = ButtonFactory.BuildButton("buttonInfo", ButtonSize.Tiny, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\question.png");
            Button buttonFav = ButtonFactory.BuildButton("buttonFav", ButtonSize.Tiny, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\star.png");


            buttonInfo.Click += (object sender, EventArgs e) => { ItemInfoForm itemInfoForm = new ItemInfoForm(); itemInfoForm.ShowDialog(); };

            panelControlsLeft.Controls.AddRange([buttonInfo, buttonFav]);

            FlowLayoutPanel panelControlsRight = new FlowLayoutPanel();
            //panelControlsRight.Dock = DockStyle.Right;
            panelControlsRight.Size = new Size(150, 40);
            panelControlsRight.Padding = new Padding(0);
            panelControlsRight.Left = 150;
            panelControlsRight.FlowDirection = FlowDirection.RightToLeft;

            
            Button buttonBuy = ButtonFactory.BuildButton("buttonBuy", ButtonSize.Small, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\salary.png");

            buttonBuy.Click += async (object sender, EventArgs e) =>
            {
                var result = MessageBox.Show($"Confirm your purchase of {marketItem.Title} for {marketItem.PriceStart}$.",
                    "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    int orderId = await DataAccess.AddItemToOrder(User.Instance().Id, marketItem.Id);

                    FormMethods.RemoveControlByGrandChild(panelInner);

                    await DataAccess.SaveHistory(User.Instance().Id, marketItem.OwnerId, marketItem.Id, (int)OperationType.Buy, marketItem.PriceEnd);
                    await DataAccess.SaveHistory(marketItem.OwnerId, User.Instance().Id, marketItem.Id, (int)OperationType.Buy, marketItem.PriceEnd);

                    MessageBox.Show($"Order #{orderId} registered.");
                }
            };

            panelControlsRight.Controls.Add(buttonBuy);


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

                        switch(bidResult)
                        {
                            case 0:
                                // todo string possibleReason = "";
                                MessageBox.Show($"Unable to bid.");
                                break;
                            case 1:
                                MessageBox.Show("Bid is successful.");
                                FormMethods.RemoveControlByGrandChild(panelInner);
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

                panelControlsRight.Controls.Add(buttonBid);
            }

            controlWrapperPanel.Controls.Add(panelControlsLeft);
            controlWrapperPanel.Controls.Add(panelControlsRight);

            panelInner.Controls.Add(textBox);
            panelInner.Controls.Add(controlWrapperPanel);

            return panelInner;
        }
    }
}
