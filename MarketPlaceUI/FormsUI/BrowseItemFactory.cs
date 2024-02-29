using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.Supporting;

namespace MarketPlaceUI.FormsUI
{
    internal static class BrowseItemFactory
    {
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
    }
}
