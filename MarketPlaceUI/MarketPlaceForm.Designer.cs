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
            labelBalance = new Label();
            labelLogin = new Label();
            buttonAccount = new Button();
            buttonAuth = new Button();
            buttonHistory = new Button();
            buttonMyItems = new Button();
            buttonBrowse = new Button();
            buttonMenuMain = new Button();
            panel1 = new Panel();
            panelHeader = new Panel();
            flowLayoutPanelHeaderControls = new FlowLayoutPanel();
            buttonMails = new Button();
            imageList = new ImageList(components);
            panelContent = new Panel();
            panel2 = new Panel();
            panelMenuLeft.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenuLeft
            // 
            panelMenuLeft.BackColor = Color.Azure;
            panelMenuLeft.Controls.Add(labelBalance);
            panelMenuLeft.Controls.Add(labelLogin);
            panelMenuLeft.Controls.Add(buttonAccount);
            panelMenuLeft.Controls.Add(buttonAuth);
            panelMenuLeft.Controls.Add(buttonHistory);
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
            // labelBalance
            // 
            labelBalance.AutoSize = true;
            labelBalance.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelBalance.Location = new Point(81, 375);
            labelBalance.Name = "labelBalance";
            labelBalance.Size = new Size(54, 45);
            labelBalance.TabIndex = 9;
            labelBalance.Text = "0$";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelLogin.ForeColor = Color.Black;
            labelLogin.Location = new Point(68, 327);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(84, 37);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "Login";
            // 
            // buttonAccount
            // 
            buttonAccount.BackColor = Color.SkyBlue;
            buttonAccount.Dock = DockStyle.Bottom;
            buttonAccount.FlatAppearance.BorderSize = 0;
            buttonAccount.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonAccount.FlatStyle = FlatStyle.Flat;
            buttonAccount.Location = new Point(0, 473);
            buttonAccount.Name = "buttonAccount";
            buttonAccount.Size = new Size(220, 44);
            buttonAccount.TabIndex = 8;
            buttonAccount.Text = "Account";
            buttonAccount.UseVisualStyleBackColor = false;
            buttonAccount.Click += buttonAccount_Click;
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
            buttonHistory.Location = new Point(0, 232);
            buttonHistory.Margin = new Padding(4);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(220, 44);
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
            buttonMyItems.FlatAppearance.BorderSize = 0;
            buttonMyItems.FlatAppearance.MouseDownBackColor = Color.SkyBlue;
            buttonMyItems.FlatStyle = FlatStyle.Flat;
            buttonMyItems.Location = new Point(0, 188);
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
            buttonBrowse.Location = new Point(0, 144);
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
            buttonMenuMain.Location = new Point(0, 100);
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
            panel1.Size = new Size(220, 100);
            panel1.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaption;
            panelHeader.Controls.Add(panel2);
            panelHeader.Controls.Add(flowLayoutPanelHeaderControls);
            panelHeader.Controls.Add(buttonMails);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(220, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 0, 0, 0);
            panelHeader.Size = new Size(964, 50);
            panelHeader.TabIndex = 1;
            // 
            // flowLayoutPanelHeaderControls
            // 
            flowLayoutPanelHeaderControls.BackColor = Color.SkyBlue;
            flowLayoutPanelHeaderControls.Location = new Point(5, 5);
            flowLayoutPanelHeaderControls.Name = "flowLayoutPanelHeaderControls";
            flowLayoutPanelHeaderControls.Size = new Size(872, 40);
            flowLayoutPanelHeaderControls.TabIndex = 2;
            // 
            // buttonMails
            // 
            buttonMails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonMails.FlatAppearance.BorderSize = 0;
            buttonMails.FlatStyle = FlatStyle.Flat;
            buttonMails.ImageIndex = 0;
            buttonMails.ImageList = imageList;
            buttonMails.Location = new Point(889, 5);
            buttonMails.Margin = new Padding(0);
            buttonMails.Name = "buttonMails";
            buttonMails.Size = new Size(40, 40);
            buttonMails.TabIndex = 0;
            buttonMails.UseVisualStyleBackColor = true;
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
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(220, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(964, 511);
            panelContent.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.Location = new Point(940, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(21, 39);
            panel2.TabIndex = 3;
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
            panelMenuLeft.PerformLayout();
            panelHeader.ResumeLayout(false);
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
    }
}
