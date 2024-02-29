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
            panel1 = new Panel();
            labelBalance = new Label();
            labelLogin = new Label();
            panelHeader = new Panel();
            panel2 = new Panel();
            flowLayoutPanelHeaderControls = new FlowLayoutPanel();
            buttonMails = new Button();
            imageList = new ImageList(components);
            panelContent = new Panel();
            panel3 = new Panel();
            panelMenuLeft.SuspendLayout();
            panel1.SuspendLayout();
            panelHeader.SuspendLayout();
            panel3.SuspendLayout();
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
            panelMenuLeft.Controls.Add(panel1);
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
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(labelBalance);
            panel1.Controls.Add(labelLogin);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 100);
            panel1.TabIndex = 2;
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
            panelHeader.Controls.Add(panel2);
            panelHeader.Controls.Add(flowLayoutPanelHeaderControls);
            panelHeader.Controls.Add(buttonMails);
            panelHeader.Location = new Point(219, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 0, 0, 0);
            panelHeader.Size = new Size(938, 51);
            panelHeader.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Location = new Point(862, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(70, 39);
            panel2.TabIndex = 3;
            // 
            // flowLayoutPanelHeaderControls
            // 
            flowLayoutPanelHeaderControls.BackColor = Color.SkyBlue;
            flowLayoutPanelHeaderControls.Location = new Point(5, 5);
            flowLayoutPanelHeaderControls.Name = "flowLayoutPanelHeaderControls";
            flowLayoutPanelHeaderControls.Size = new Size(811, 40);
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
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(panelMenuLeft);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(219, 559);
            panel3.TabIndex = 0;
            // 
            // MarketPlaceForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1156, 559);
            Controls.Add(panel3);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "MarketPlaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelMenuLeft.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLeft;
        private Panel panelHeader;
        private Panel panel1;
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
        private Panel panel2;
        private Panel panel3;
    }
}
