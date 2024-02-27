namespace MarketPlaceUI
{
    partial class MarketPlaceForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenuLeft = new Panel();
            buttonAuth = new Button();
            buttonHistory = new Button();
            buttonFavorite = new Button();
            buttonMyItems = new Button();
            buttonBrowse = new Button();
            buttonMenuMain = new Button();
            panel1 = new Panel();
            panelHeader = new Panel();
            buttonCart = new Button();
            buttonMails = new Button();
            panelContent = new Panel();
            richTextBox1 = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            panelMenuLeft.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLeft
            // 
            panelMenuLeft.BackColor = SystemColors.ActiveCaption;
            panelMenuLeft.Controls.Add(buttonAuth);
            panelMenuLeft.Controls.Add(buttonHistory);
            panelMenuLeft.Controls.Add(buttonFavorite);
            panelMenuLeft.Controls.Add(buttonMyItems);
            panelMenuLeft.Controls.Add(buttonBrowse);
            panelMenuLeft.Controls.Add(buttonMenuMain);
            panelMenuLeft.Controls.Add(panel1);
            panelMenuLeft.Dock = DockStyle.Left;
            panelMenuLeft.Location = new Point(0, 0);
            panelMenuLeft.Margin = new Padding(0);
            panelMenuLeft.Name = "panelMenuLeft";
            panelMenuLeft.Size = new Size(220, 561);
            panelMenuLeft.TabIndex = 0;
            // 
            // buttonAuth
            // 
            buttonAuth.Location = new Point(50, 505);
            buttonAuth.Name = "buttonAuth";
            buttonAuth.Size = new Size(107, 44);
            buttonAuth.TabIndex = 0;
            buttonAuth.Text = "Auth";
            buttonAuth.UseVisualStyleBackColor = true;
            buttonAuth.Click += buttonAuth_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonHistory.Dock = DockStyle.Top;
            buttonHistory.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonHistory.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            buttonHistory.FlatStyle = FlatStyle.Flat;
            buttonHistory.Location = new Point(0, 229);
            buttonHistory.Margin = new Padding(4);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(220, 39);
            buttonHistory.TabIndex = 7;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonFavorite
            // 
            buttonFavorite.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonFavorite.Dock = DockStyle.Top;
            buttonFavorite.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonFavorite.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            buttonFavorite.FlatStyle = FlatStyle.Flat;
            buttonFavorite.Location = new Point(0, 190);
            buttonFavorite.Margin = new Padding(4);
            buttonFavorite.Name = "buttonFavorite";
            buttonFavorite.Size = new Size(220, 39);
            buttonFavorite.TabIndex = 6;
            buttonFavorite.Text = "Favorite";
            buttonFavorite.UseVisualStyleBackColor = true;
            buttonFavorite.Click += buttonFavorite_Click;
            // 
            // buttonMyItems
            // 
            buttonMyItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMyItems.Dock = DockStyle.Top;
            buttonMyItems.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonMyItems.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            buttonMyItems.FlatStyle = FlatStyle.Flat;
            buttonMyItems.Location = new Point(0, 151);
            buttonMyItems.Margin = new Padding(4);
            buttonMyItems.Name = "buttonMyItems";
            buttonMyItems.Size = new Size(220, 39);
            buttonMyItems.TabIndex = 5;
            buttonMyItems.Text = "My Items";
            buttonMyItems.UseVisualStyleBackColor = true;
            buttonMyItems.Click += buttonMyItems_Click;
            // 
            // buttonBrowse
            // 
            buttonBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonBrowse.Dock = DockStyle.Top;
            buttonBrowse.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonBrowse.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            buttonBrowse.FlatStyle = FlatStyle.Flat;
            buttonBrowse.Location = new Point(0, 112);
            buttonBrowse.Margin = new Padding(4);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(220, 39);
            buttonBrowse.TabIndex = 4;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonMenuMain
            // 
            buttonMenuMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMenuMain.Dock = DockStyle.Top;
            buttonMenuMain.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonMenuMain.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            buttonMenuMain.FlatStyle = FlatStyle.Flat;
            buttonMenuMain.Location = new Point(0, 73);
            buttonMenuMain.Margin = new Padding(4);
            buttonMenuMain.Name = "buttonMenuMain";
            buttonMenuMain.Size = new Size(220, 39);
            buttonMenuMain.TabIndex = 3;
            buttonMenuMain.Text = "Main";
            buttonMenuMain.UseVisualStyleBackColor = true;
            buttonMenuMain.Click += buttonMenuMain_Click;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 73);
            panel1.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(buttonCart);
            panelHeader.Controls.Add(buttonMails);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(220, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(964, 73);
            panelHeader.TabIndex = 1;
            // 
            // buttonCart
            // 
            buttonCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCart.FlatStyle = FlatStyle.Flat;
            buttonCart.Location = new Point(922, 34);
            buttonCart.Margin = new Padding(0);
            buttonCart.Name = "buttonCart";
            buttonCart.Size = new Size(42, 39);
            buttonCart.TabIndex = 1;
            buttonCart.Text = "C";
            buttonCart.UseVisualStyleBackColor = true;
            // 
            // buttonMails
            // 
            buttonMails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMails.FlatStyle = FlatStyle.Flat;
            buttonMails.Location = new Point(880, 34);
            buttonMails.Margin = new Padding(0);
            buttonMails.Name = "buttonMails";
            buttonMails.Size = new Size(42, 39);
            buttonMails.TabIndex = 0;
            buttonMails.Text = "M";
            buttonMails.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ActiveBorder;
            panelContent.Controls.Add(richTextBox1);
            panelContent.Controls.Add(tableLayoutPanel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 73);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(964, 488);
            panelContent.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(291, 268);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(237, 96);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel1.Location = new Point(184, 95);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(385, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(182, 50);
            textBox1.TabIndex = 2;
            textBox1.Text = "A really long description for the Item #{i}, where everything is mentioned. It could be small or very large.";
            // 
            // MarketPlaceForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1184, 561);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelMenuLeft);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "MarketPlaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelMenuLeft.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLeft;
        private Panel panelHeader;
        private Panel panel1;
        private Button buttonMenuMain;
        private Button buttonHistory;
        private Button buttonFavorite;
        private Button buttonMyItems;
        private Button buttonBrowse;
        private Button buttonMails;
        private Button buttonCart;
        private Panel panelContent;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button buttonAuth;
    }
}
