using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.FormsUI;
using System.Diagnostics;
using System.Windows.Forms;
using MarketPlaceUI.Supporting;

namespace MarketPlaceUI
{
    public partial class MarketPlaceForm : Form
    {
        private CurrentForm _currentForm = CurrentForm.Main;         
        public MarketPlaceForm()
        {
            InitializeComponent();
        }

        private void buttonMenuMain_Click(object sender, EventArgs e)
        {
            if (_currentForm == CurrentForm.Main)
            {
                return;
            }
            _currentForm = CurrentForm.Main;
            flowLayoutPanelHeaderControls.Controls.Clear();

            panelContent.Controls.Clear();

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Text = "ABC";

            panelContent.Controls.Add(richTextBox);

        }

        private async void buttonBrowse_Click(object sender, EventArgs e)
        {
            // TODO - scrollbar issue
            if (_currentForm == CurrentForm.Browse)
            {
                return;
            }
            _currentForm = CurrentForm.Browse;
            flowLayoutPanelHeaderControls.Controls.Clear();

            panelContent.Controls.Clear();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Name = "flowLayoutPanel2";
            flowLayoutPanel.Visible = true;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // TODO - ownerId
            List<MarketItem> marketItems = await DataAccess.GetMarketItems(1, 20, User.Instance().Id);


            foreach (MarketItem marketItem in marketItems)
            {
                Panel panel = new Panel();
                panel.Size = new Size(300, 300);
                //panel.Visible = false;

                PictureBox pictureBox = BrowseItemFactory.BuildBrowseHeaderBox(marketItem);

                // TODO - simplify?
                Task.Run(() => { pictureBox.Image = LoadImageAsync(marketItem.Id).Result; });

                TableLayoutPanel panelInner = BrowseItemFactory.BuildBrowseFooterBox(marketItem);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(panelInner);

                flowLayoutPanel.Controls.Add(panel);
            }

            panelContent.Controls.Add(flowLayoutPanel);

        }

        private async void buttonMyItems_Click(object sender, EventArgs e)
        {
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
            dataGridView.Columns.AddRange([
                columnTitle, columnCategory, columnPriceStart, columnPriceCurrent, columnPriceEnd,
                columnBidStep, columnDateStart, columnDateEnd//, columnEditButton
                ]);
            dataGridView.Name = "dataGridView1";

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

            Button addItemButton = ButtonFactory.BuildButton("addItemButton", ButtonSize.Small, new Point(60, 0), text: "Item");

            addItemButton.Click += addItemButton_Click;

            flowLayoutPanelHeaderControls.Controls.Add(addItemButton);

            void addItemButton_Click(object sender, EventArgs e)
            {
                ItemSaleForm itemAddForm = new ItemSaleForm();
                itemAddForm.ShowDialog();
            }
        }

        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            if (_currentForm == CurrentForm.Favorites)
            {
                return;
            }
            _currentForm = CurrentForm.Favorites;
            flowLayoutPanelHeaderControls.Controls.Clear();

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
            if (_currentForm == CurrentForm.History)
            {
                return;
            }
            _currentForm = CurrentForm.History;
            flowLayoutPanelHeaderControls.Controls.Clear();

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

        

        // TODO - for all controls?
        private async Task<Image> LoadImageAsync(int itemId)
        {
            byte[] imageData = await DataAccess.RetrieveImageFromDatabase(itemId);

            TaskCompletionSource<Image> tcs = new TaskCompletionSource<Image>();

            if (imageData == null)
            {
                tcs.SetResult(Image.FromFile(@"D:\Programming\projects\MarketPlace\Assets\NO_IMAGE.png"));
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
