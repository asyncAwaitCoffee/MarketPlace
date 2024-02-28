using MarketPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Label label = new Label();
            label.Text = marketItem.Title;
            label.Top = pictureBox.Height - label.Height;
            label.Left = 0;
            label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label.BackColor = Color.Transparent;

            pictureBox.Controls.Add(label);

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
            textBox.ReadOnly = true;

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
            Button buttonBid = ButtonFactory.BuildButton("buttonBid", ButtonSize.Small, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\profits.png");
            Button buttonBuy = ButtonFactory.BuildButton("buttonBuy", ButtonSize.Small, new Point(0, 0), imagePath: @"D:\Programming\projects\MarketPlace\Assets\salary.png");


            panelControlsRight.Controls.AddRange([buttonBuy, buttonBid]);

            controlWrapperPanel.Controls.Add(panelControlsLeft);
            controlWrapperPanel.Controls.Add(panelControlsRight);

            panelInner.Controls.Add(textBox);
            panelInner.Controls.Add(controlWrapperPanel);

            return panelInner;
        }
    }
}
