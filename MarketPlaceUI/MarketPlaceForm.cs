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
            foreach (Control control in panelContent.Controls)
            {
                control.Dispose();
            }
            panelContent.Controls.Clear();

            // Header controls add            

            flowLayoutPanelHeaderControls.Controls.AddRange(BrowseItemFactory.BuildHeaderControls(panelContent));

            // TODO - pageNo
            List<MarketItem> marketItems = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id);

            FlowLayoutPanel panelAllItemsContainer = BrowseItemFactory.BuildAllItemsContainer();

            foreach (var item in marketItems)
            {
                panelAllItemsContainer.Controls.Add(BrowseItemFactory.BuildItemContainer(item));
            }

            panelContent.Controls.Add(panelAllItemsContainer);           
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

            List<MarketItem> myMarketItems = await DataAccess.GetMarketItems(AppState.CurrentPage, AppState.ItemsPerPage, User.Instance().Id, filterByOwnerId: true);

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
