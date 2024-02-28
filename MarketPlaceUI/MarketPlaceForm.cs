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

        private void buttonMyItems_Click(object sender, EventArgs e)
        {
            if (_currentForm == CurrentForm.MyItems)
            {
                return;
            }
            _currentForm = CurrentForm.MyItems;

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

            Button addItemButton = ButtonFactory.BuildButton("addItemButton", ButtonSize.Small, new Point(0, 0), text: "Add item");
            addItemButton.Click += addItemButton_Click;

            panelHeaderControls.Controls.Add(addItemButton);
        }

        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            if (_currentForm == CurrentForm.Favorites)
            {
                return;
            }
            _currentForm = CurrentForm.Favorites;

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
