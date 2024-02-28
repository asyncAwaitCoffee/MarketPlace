using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.FormsUI;
using System.Diagnostics;
using System.Windows.Forms;

namespace MarketPlaceUI
{
    public partial class MarketPlaceForm : Form
    {
        public MarketPlaceForm()
        {
            InitializeComponent();
        }

        private void buttonMenuMain_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = "ABC";

            panelContent.Controls.Add(richTextBox);

        }

        private async void buttonBrowse_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Name = "flowLayoutPanel2";
            flowLayoutPanel.Visible = true;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            List<MarketItem> marketItems = await DataAccess.GetMarketItems(1, 20, 1);


            foreach (MarketItem marketItem in marketItems)
            {
                Panel panel = new Panel();
                panel.Size = new Size(300, 300);

                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.PeachPuff;
                pictureBox.Size = new Size(300, 200);


                Label label = new Label();
                label.Text = marketItem.Title;
                label.Top = pictureBox.Height - label.Height;
                label.Left = 0;
                label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                label.BackColor = Color.Transparent;

                // TODO - simplify?
                Task.Run(() =>
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = LoadImageAsync(marketItem.Id).Result;
                });


                pictureBox.Controls.Add(label);

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
                Button buttonInfo = ButtonFactory.BuildButton("buttonInfo", "?", ButtonSize.Tiny, new Point(0, 0));
                Button buttonFav = ButtonFactory.BuildButton("buttonFav", "Fav", ButtonSize.Tiny, new Point(0, 0));
                
                buttonInfo.Click += (object sender, EventArgs e) => { ItemInfoForm itemInfoForm = new ItemInfoForm(); itemInfoForm.ShowDialog(); };

                panelControlsLeft.Controls.AddRange([buttonInfo, buttonFav]);

                FlowLayoutPanel panelControlsRight = new FlowLayoutPanel();
                //panelControlsRight.Dock = DockStyle.Right;
                panelControlsRight.Size = new Size(150, 40);
                panelControlsRight.Padding = new Padding(0);
                panelControlsRight.Left = 150;
                panelControlsRight.FlowDirection = FlowDirection.RightToLeft;
                Button buttonBid = ButtonFactory.BuildButton("buttonBid", "Bid", ButtonSize.Small, new Point(0, 0));
                Button buttonBuy = ButtonFactory.BuildButton("buttonBuy", "Buy", ButtonSize.Small, new Point(0, 0));


                panelControlsRight.Controls.AddRange([buttonBuy, buttonBid]);

                controlWrapperPanel.Controls.Add(panelControlsLeft);
                controlWrapperPanel.Controls.Add(panelControlsRight);

                panelInner.Controls.Add(textBox);
                panelInner.Controls.Add(controlWrapperPanel);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(panelInner);

                flowLayoutPanel.Controls.Add(panel);
            }

            panelContent.Controls.Add(flowLayoutPanel);

        }

        private void buttonMyItems_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn columnTitle = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn columnEditButton = new DataGridViewButtonColumn();

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { columnTitle, columnEditButton });
            dataGridView.Name = "dataGridView1";

            columnTitle.HeaderText = "Title";
            columnTitle.Name = "columnTitle";
            columnEditButton.HeaderText = "Edit";
            columnEditButton.Name = "columnEditButton";

            panelContent.Controls.Add(dataGridView);

            Button addItemButton = ButtonFactory.BuildButton("addItemButton", "Add item", ButtonSize.Small, new Point(0, 0));
            addItemButton.Click += addItemButton_Click;

            panelHeaderControls.Controls.Add(addItemButton);
        }

        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Name = "flowLayoutPanel2";
            flowLayoutPanel.Visible = true;
            flowLayoutPanel.AutoScroll = true;

            for (int i = 0; i < 10; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(200, 200);
                panel.BackColor = Color.DarkOliveGreen;

                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.GreenYellow;
                pictureBox.Size = new Size(200, 100);

                Label label = new Label();
                label.Text = $"Item #{i}";
                label.Top = pictureBox.Height - label.Height;
                label.Left = 0;
                label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

                pictureBox.Controls.Add(label);

                panel.Controls.Add(pictureBox);

                flowLayoutPanel.Controls.Add(panel);
            }

            panelContent.Controls.Add(flowLayoutPanel);

        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            DataGridViewTextBoxColumn columnTitle = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnCustomer = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn columnDateDone = new DataGridViewTextBoxColumn();

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { columnTitle, columnCustomer, columnDateDone });
            dataGridView.Name = "dataGridView1";

            columnTitle.HeaderText = "Title";
            columnTitle.Name = "columnTitle";
            columnCustomer.HeaderText = "Customer";
            columnCustomer.Name = "columnCustomer";
            columnDateDone.HeaderText = "Date";
            columnDateDone.Name = "columnDate";

            panelContent.Controls.Add(dataGridView);
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                DataAccess.SaveImageToDatabase(imagePath);
            }
        }

        // TODO - for all controls?
        private async Task<Image> LoadImageAsync(int id)
        {
            byte[] imageData = await DataAccess.RetrieveImageFromDatabase(id);

            TaskCompletionSource<Image> tcs = new TaskCompletionSource<Image>();

            await Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    tcs.SetResult(Image.FromStream(ms));
                }
            });

            return await tcs.Task;
        }
    }
}
