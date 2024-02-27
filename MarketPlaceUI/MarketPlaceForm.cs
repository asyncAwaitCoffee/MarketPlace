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

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            flowLayoutPanel.BackColor = Color.Green;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Name = "flowLayoutPanel2";
            flowLayoutPanel.Visible = true;
            flowLayoutPanel.AutoScroll = true;

            for (int i = 0; i < 10; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(300, 300);

                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.PeachPuff;
                pictureBox.Size = new Size(300, 150);

                Label label = new Label();
                label.Text = $"Item #{i}";
                label.Top = pictureBox.Height - label.Height;
                label.Left = 0;
                label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

                pictureBox.Controls.Add(label);

                TableLayoutPanel panelInner = new TableLayoutPanel();
                panelInner.BackColor = Color.LightPink;
                panelInner.Size = new Size(300, 150);
                panelInner.Dock = DockStyle.Bottom;
                panelInner.ColumnCount = 1;
                panelInner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                panelInner.RowCount = 2;
                panelInner.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                panelInner.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

                TextBox textBox = new TextBox();
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.BackColor = Color.WhiteSmoke;
                textBox.Dock = DockStyle.Fill;
                textBox.Margin = new Padding(0);
                textBox.Text = $"A really long description for the Item #{i}, where everything is mentioned. It could be small or very large.";
                textBox.ReadOnly = true;

                panelInner.Controls.Add(textBox);

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

        }

        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

            flowLayoutPanel.BackColor = Color.BlueViolet;
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
    }
}
