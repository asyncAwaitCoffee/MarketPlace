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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketPlaceForm));
            panelMenuLeft = new Panel();
            buttonAuth = new Button();
            buttonHistory = new Button();
            buttonFavorite = new Button();
            buttonMyItems = new Button();
            buttonBrowse = new Button();
            buttonMenuMain = new Button();
            panel1 = new Panel();
            panelHeader = new Panel();
            panelHeaderControls = new Panel();
            buttonCart = new Button();
            buttonMails = new Button();
            panelContent = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            panelMenuLeft.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLeft
            // 
            panelMenuLeft.BackColor = Color.Azure;
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
            buttonAuth.BackColor = Color.SkyBlue;
            buttonAuth.Dock = DockStyle.Bottom;
            buttonAuth.FlatAppearance.BorderSize = 0;
            buttonAuth.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonAuth.FlatStyle = FlatStyle.Flat;
            buttonAuth.Location = new Point(0, 517);
            buttonAuth.Name = "buttonAuth";
            buttonAuth.Size = new Size(220, 44);
            buttonAuth.TabIndex = 0;
            buttonAuth.Text = "Auth";
            buttonAuth.UseVisualStyleBackColor = false;
            buttonAuth.Click += buttonAuth_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonHistory.BackColor = Color.LightSkyBlue;
            buttonHistory.Dock = DockStyle.Top;
            buttonHistory.FlatAppearance.BorderSize = 0;
            buttonHistory.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonHistory.FlatStyle = FlatStyle.Flat;
            buttonHistory.Location = new Point(0, 217);
            buttonHistory.Margin = new Padding(4);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(220, 44);
            buttonHistory.TabIndex = 7;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = false;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonFavorite
            // 
            buttonFavorite.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonFavorite.BackColor = Color.LightSkyBlue;
            buttonFavorite.Dock = DockStyle.Top;
            buttonFavorite.FlatAppearance.BorderSize = 0;
            buttonFavorite.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonFavorite.FlatStyle = FlatStyle.Flat;
            buttonFavorite.Location = new Point(0, 173);
            buttonFavorite.Margin = new Padding(4);
            buttonFavorite.Name = "buttonFavorite";
            buttonFavorite.Size = new Size(220, 44);
            buttonFavorite.TabIndex = 6;
            buttonFavorite.Text = "Favorite";
            buttonFavorite.UseVisualStyleBackColor = false;
            buttonFavorite.Click += buttonFavorite_Click;
            // 
            // buttonMyItems
            // 
            buttonMyItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMyItems.BackColor = Color.LightSkyBlue;
            buttonMyItems.Dock = DockStyle.Top;
            buttonMyItems.FlatAppearance.BorderSize = 0;
            buttonMyItems.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonMyItems.FlatStyle = FlatStyle.Flat;
            buttonMyItems.Location = new Point(0, 129);
            buttonMyItems.Margin = new Padding(4);
            buttonMyItems.Name = "buttonMyItems";
            buttonMyItems.Size = new Size(220, 44);
            buttonMyItems.TabIndex = 5;
            buttonMyItems.Text = "My Items";
            buttonMyItems.UseVisualStyleBackColor = false;
            buttonMyItems.Click += buttonMyItems_Click;
            // 
            // buttonBrowse
            // 
            buttonBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonBrowse.BackColor = Color.LightSkyBlue;
            buttonBrowse.Dock = DockStyle.Top;
            buttonBrowse.FlatAppearance.BorderSize = 0;
            buttonBrowse.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonBrowse.FlatStyle = FlatStyle.Flat;
            buttonBrowse.Location = new Point(0, 85);
            buttonBrowse.Margin = new Padding(4);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(220, 44);
            buttonBrowse.TabIndex = 4;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = false;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonMenuMain
            // 
            buttonMenuMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMenuMain.BackColor = Color.LightSkyBlue;
            buttonMenuMain.Dock = DockStyle.Top;
            buttonMenuMain.FlatAppearance.BorderSize = 0;
            buttonMenuMain.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonMenuMain.FlatStyle = FlatStyle.Flat;
            buttonMenuMain.Location = new Point(0, 41);
            buttonMenuMain.Margin = new Padding(4);
            buttonMenuMain.Name = "buttonMenuMain";
            buttonMenuMain.Size = new Size(220, 44);
            buttonMenuMain.TabIndex = 3;
            buttonMenuMain.Text = "Main";
            buttonMenuMain.UseVisualStyleBackColor = false;
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
            panel1.Size = new Size(220, 41);
            panel1.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(panelHeaderControls);
            panelHeader.Controls.Add(buttonCart);
            panelHeader.Controls.Add(buttonMails);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(220, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 0, 0, 0);
            panelHeader.Size = new Size(964, 40);
            panelHeader.TabIndex = 1;
            // 
            // panelHeaderControls
            // 
            panelHeaderControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelHeaderControls.BackColor = Color.Transparent;
            panelHeaderControls.Location = new Point(182, 6);
            panelHeaderControls.Margin = new Padding(0);
            panelHeaderControls.Name = "panelHeaderControls";
            panelHeaderControls.Size = new Size(600, 28);
            panelHeaderControls.TabIndex = 2;
            // 
            // buttonCart
            // 
            buttonCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCart.FlatStyle = FlatStyle.Flat;
            buttonCart.Location = new Point(922, 1);
            buttonCart.Margin = new Padding(0);
            buttonCart.Name = "buttonCart";
            buttonCart.Size = new Size(40, 40);
            buttonCart.TabIndex = 1;
            buttonCart.Text = "C";
            buttonCart.UseVisualStyleBackColor = true;
            // 
            // buttonMails
            // 
            buttonMails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMails.FlatStyle = FlatStyle.Flat;
            buttonMails.Location = new Point(880, 1);
            buttonMails.Margin = new Padding(0);
            buttonMails.Name = "buttonMails";
            buttonMails.Size = new Size(40, 40);
            buttonMails.TabIndex = 0;
            buttonMails.Text = "M";
            buttonMails.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ActiveBorder;
            panelContent.Controls.Add(button1);
            panelContent.Controls.Add(flowLayoutPanel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 40);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(964, 521);
            panelContent.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(268, 133);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(222, 127);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(417, 288);
            button1.Name = "button1";
            button1.Size = new Size(75, 67);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
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
        private Button buttonAuth;
        private Panel panelHeaderControls;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
    }
}
