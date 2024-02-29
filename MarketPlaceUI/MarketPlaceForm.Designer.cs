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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketPlaceForm));
            panelMenuLeft = new Panel();
            buttonAccount = new Button();
            buttonAuth = new Button();
            buttonHistory = new Button();
            buttonMyItems = new Button();
            buttonBrowse = new Button();
            buttonMenuMain = new Button();
            panelAccountInfo = new Panel();
            labelBalance = new Label();
            labelLogin = new Label();
            panelHeader = new Panel();
            panelHeaderStyle7 = new Panel();
            panelHeaderStyle6 = new Panel();
            panelHeaderStyle5 = new Panel();
            panelHeaderStyle4 = new Panel();
            panelHeaderStyle2 = new Panel();
            flowLayoutPanelHeaderControls = new FlowLayoutPanel();
            buttonMails = new Button();
            imageList = new ImageList(components);
            panelContent = new Panel();
            panelLeftMenuDock = new Panel();
            panelMenuLeft.SuspendLayout();
            panelAccountInfo.SuspendLayout();
            panelHeader.SuspendLayout();
            panelLeftMenuDock.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLeft
            // 
            panelMenuLeft.BackColor = SystemColors.ActiveCaption;
            panelMenuLeft.Controls.Add(buttonAccount);
            panelMenuLeft.Controls.Add(buttonAuth);
            panelMenuLeft.Controls.Add(buttonHistory);
            panelMenuLeft.Controls.Add(buttonMyItems);
            panelMenuLeft.Controls.Add(buttonBrowse);
            panelMenuLeft.Controls.Add(buttonMenuMain);
            panelMenuLeft.Controls.Add(panelAccountInfo);
            panelMenuLeft.Location = new Point(5, 5);
            panelMenuLeft.Margin = new Padding(0);
            panelMenuLeft.Name = "panelMenuLeft";
            panelMenuLeft.Size = new Size(210, 550);
            panelMenuLeft.TabIndex = 0;
            // 
            // buttonAccount
            // 
            buttonAccount.BackColor = Color.LightSkyBlue;
            buttonAccount.Dock = DockStyle.Bottom;
            buttonAccount.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonAccount.FlatAppearance.BorderSize = 2;
            buttonAccount.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonAccount.FlatStyle = FlatStyle.Flat;
            buttonAccount.Location = new Point(0, 462);
            buttonAccount.Name = "buttonAccount";
            buttonAccount.Size = new Size(210, 44);
            buttonAccount.TabIndex = 8;
            buttonAccount.Text = "Account";
            buttonAccount.UseVisualStyleBackColor = false;
            buttonAccount.Click += buttonAccount_Click;
            // 
            // buttonAuth
            // 
            buttonAuth.BackColor = Color.LightSkyBlue;
            buttonAuth.Dock = DockStyle.Bottom;
            buttonAuth.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonAuth.FlatAppearance.BorderSize = 2;
            buttonAuth.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonAuth.FlatStyle = FlatStyle.Flat;
            buttonAuth.Location = new Point(0, 506);
            buttonAuth.Name = "buttonAuth";
            buttonAuth.Size = new Size(210, 44);
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
            buttonHistory.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonHistory.FlatAppearance.BorderSize = 2;
            buttonHistory.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonHistory.FlatStyle = FlatStyle.Flat;
            buttonHistory.Location = new Point(0, 232);
            buttonHistory.Margin = new Padding(4);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(210, 44);
            buttonHistory.TabIndex = 7;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = false;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonMyItems
            // 
            buttonMyItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonMyItems.BackColor = Color.LightSkyBlue;
            buttonMyItems.Dock = DockStyle.Top;
            buttonMyItems.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonMyItems.FlatAppearance.BorderSize = 2;
            buttonMyItems.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonMyItems.FlatStyle = FlatStyle.Flat;
            buttonMyItems.Location = new Point(0, 188);
            buttonMyItems.Margin = new Padding(4);
            buttonMyItems.Name = "buttonMyItems";
            buttonMyItems.Size = new Size(210, 44);
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
            buttonBrowse.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonBrowse.FlatAppearance.BorderSize = 2;
            buttonBrowse.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonBrowse.FlatStyle = FlatStyle.Flat;
            buttonBrowse.Location = new Point(0, 144);
            buttonBrowse.Margin = new Padding(4);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(210, 44);
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
            buttonMenuMain.FlatAppearance.BorderColor = SystemColors.ActiveCaption;
            buttonMenuMain.FlatAppearance.BorderSize = 2;
            buttonMenuMain.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonMenuMain.FlatStyle = FlatStyle.Flat;
            buttonMenuMain.Location = new Point(0, 100);
            buttonMenuMain.Margin = new Padding(4);
            buttonMenuMain.Name = "buttonMenuMain";
            buttonMenuMain.Size = new Size(210, 44);
            buttonMenuMain.TabIndex = 3;
            buttonMenuMain.Text = "Main";
            buttonMenuMain.UseVisualStyleBackColor = false;
            buttonMenuMain.Click += buttonMenuMain_Click;
            // 
            // panelAccountInfo
            // 
            panelAccountInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelAccountInfo.BackColor = Color.CornflowerBlue;
            panelAccountInfo.Controls.Add(labelBalance);
            panelAccountInfo.Controls.Add(labelLogin);
            panelAccountInfo.Dock = DockStyle.Top;
            panelAccountInfo.Location = new Point(0, 0);
            panelAccountInfo.Margin = new Padding(0);
            panelAccountInfo.Name = "panelAccountInfo";
            panelAccountInfo.Size = new Size(210, 100);
            panelAccountInfo.TabIndex = 2;
            // 
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelBalance.ForeColor = Color.White;
            labelBalance.Location = new Point(90, 46);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(40, 32);
            labelBalance.TabIndex = 9;
            labelBalance.Text = "0$";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelLogin.ForeColor = Color.White;
            labelLogin.Location = new Point(68, 9);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(84, 37);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "Login";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(panelHeaderStyle7);
            panelHeader.Controls.Add(panelHeaderStyle6);
            panelHeader.Controls.Add(panelHeaderStyle5);
            panelHeader.Controls.Add(panelHeaderStyle4);
            panelHeader.Controls.Add(panelHeaderStyle2);
            panelHeader.Controls.Add(flowLayoutPanelHeaderControls);
            panelHeader.Controls.Add(buttonMails);
            panelHeader.Location = new Point(219, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 0, 0, 0);
            panelHeader.Size = new Size(938, 51);
            panelHeader.TabIndex = 1;
            // 
            // panelHeaderStyle7
            // 
            panelHeaderStyle7.BackColor = Color.SkyBlue;
            panelHeaderStyle7.Location = new Point(6, 6);
            panelHeaderStyle7.Name = "panelHeaderStyle7";
            panelHeaderStyle7.Size = new Size(12, 39);
            panelHeaderStyle7.TabIndex = 4;
            // 
            // panelHeaderStyle6
            // 
            panelHeaderStyle6.BackColor = Color.SkyBlue;
            panelHeaderStyle6.Location = new Point(21, 6);
            panelHeaderStyle6.Name = "panelHeaderStyle6";
            panelHeaderStyle6.Size = new Size(17, 39);
            panelHeaderStyle6.TabIndex = 4;
            // 
            // panelHeaderStyle5
            // 
            panelHeaderStyle5.BackColor = Color.SkyBlue;
            panelHeaderStyle5.Location = new Point(41, 6);
            panelHeaderStyle5.Name = "panelHeaderStyle5";
            panelHeaderStyle5.Size = new Size(34, 39);
            panelHeaderStyle5.TabIndex = 4;
            // 
            // panelHeaderStyle4
            // 
            panelHeaderStyle4.BackColor = Color.SkyBlue;
            panelHeaderStyle4.Location = new Point(78, 6);
            panelHeaderStyle4.Name = "panelHeaderStyle4";
            panelHeaderStyle4.Size = new Size(70, 39);
            panelHeaderStyle4.TabIndex = 4;
            // 
            // panelHeaderStyle2
            // 
            panelHeaderStyle2.BackColor = Color.SkyBlue;
            panelHeaderStyle2.Location = new Point(862, 6);
            panelHeaderStyle2.Name = "panelHeaderStyle2";
            panelHeaderStyle2.Size = new Size(70, 39);
            panelHeaderStyle2.TabIndex = 3;
            // 
            // flowLayoutPanelHeaderControls
            // 
            flowLayoutPanelHeaderControls.BackColor = Color.SkyBlue;
            flowLayoutPanelHeaderControls.Location = new Point(151, 5);
            flowLayoutPanelHeaderControls.Name = "flowLayoutPanelHeaderControls";
            flowLayoutPanelHeaderControls.Size = new Size(665, 40);
            flowLayoutPanelHeaderControls.TabIndex = 2;
            // 
            // buttonMails
            // 
            buttonMails.Anchor = AnchorStyles.None;
            buttonMails.FlatAppearance.BorderSize = 0;
            buttonMails.FlatStyle = FlatStyle.Flat;
            buttonMails.ImageIndex = 0;
            buttonMails.ImageList = imageList;
            buttonMails.Location = new Point(819, 5);
            buttonMails.Margin = new Padding(0);
            buttonMails.Name = "buttonMails";
            buttonMails.Size = new Size(40, 40);
            buttonMails.TabIndex = 0;
            buttonMails.UseVisualStyleBackColor = true;
            buttonMails.Click += buttonMails_Click;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "email.png");
            imageList.Images.SetKeyName(1, "email_new.png");
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ActiveBorder;
            panelContent.Location = new Point(218, 51);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(939, 519);
            panelContent.TabIndex = 3;
            // 
            // panelLeftMenuDock
            // 
            panelLeftMenuDock.BackColor = SystemColors.ActiveCaption;
            panelLeftMenuDock.Controls.Add(panelMenuLeft);
            panelLeftMenuDock.Dock = DockStyle.Left;
            panelLeftMenuDock.Location = new Point(0, 0);
            panelLeftMenuDock.Margin = new Padding(0);
            panelLeftMenuDock.Name = "panelLeftMenuDock";
            panelLeftMenuDock.Size = new Size(219, 559);
            panelLeftMenuDock.TabIndex = 0;
            // 
            // MarketPlaceForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1156, 559);
            Controls.Add(panelLeftMenuDock);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "MarketPlaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Market Place";
            panelMenuLeft.ResumeLayout(false);
            panelAccountInfo.ResumeLayout(false);
            panelAccountInfo.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelLeftMenuDock.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLeft;
        private Panel panelHeader;
        private Panel panelAccountInfo;
        private Button buttonMenuMain;
        private Button buttonHistory;
        private Button buttonMyItems;
        private Button buttonBrowse;
        private Button buttonMails;
        private Panel panelContent;
        private Button buttonAuth;
        private FlowLayoutPanel flowLayoutPanelHeaderControls;
        private Button buttonAccount;
        private ImageList imageList;
        private Label labelLogin;
        private Label labelBalance;
        private Panel panelHeaderStyle2;
        private Panel panelLeftMenuDock;
        private Panel panelHeaderStyle7;
        private Panel panelHeaderStyle6;
        private Panel panelHeaderStyle5;
        private Panel panelHeaderStyle4;
    }
}
