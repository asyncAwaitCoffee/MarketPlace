namespace MarketPlaceUI
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonRegOk = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBoxAuthUserLogin = new TextBox();
            textBoxAuthUserPassword = new TextBox();
            checkBoxStayLoggedIn = new CheckBox();
            buttonAuthOk = new Button();
            tabPage2 = new TabPage();
            linkLabelPolicy = new LinkLabel();
            checkBoxPolicy = new CheckBox();
            textBoxRegUserLogin = new TextBox();
            textBoxRegUserPassword = new TextBox();
            errorProviderReg = new ErrorProvider(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderReg).BeginInit();
            SuspendLayout();
            // 
            // buttonRegOk
            // 
            buttonRegOk.BackColor = Color.SkyBlue;
            buttonRegOk.FlatAppearance.BorderSize = 0;
            buttonRegOk.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonRegOk.FlatStyle = FlatStyle.Flat;
            buttonRegOk.Location = new Point(64, 167);
            buttonRegOk.Name = "buttonRegOk";
            buttonRegOk.Size = new Size(217, 42);
            buttonRegOk.TabIndex = 0;
            buttonRegOk.Text = "Ok";
            buttonRegOk.UseVisualStyleBackColor = false;
            buttonRegOk.Click += buttonRegOk_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 11);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(352, 273);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBoxAuthUserLogin);
            tabPage1.Controls.Add(textBoxAuthUserPassword);
            tabPage1.Controls.Add(checkBoxStayLoggedIn);
            tabPage1.Controls.Add(buttonAuthOk);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(344, 235);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Authorization";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxAuthUserLogin
            // 
            textBoxAuthUserLogin.Location = new Point(21, 30);
            textBoxAuthUserLogin.Name = "textBoxAuthUserLogin";
            textBoxAuthUserLogin.PlaceholderText = "Username";
            textBoxAuthUserLogin.Size = new Size(303, 33);
            textBoxAuthUserLogin.TabIndex = 3;
            // 
            // textBoxAuthUserPassword
            // 
            textBoxAuthUserPassword.Location = new Point(21, 83);
            textBoxAuthUserPassword.Name = "textBoxAuthUserPassword";
            textBoxAuthUserPassword.PasswordChar = '*';
            textBoxAuthUserPassword.PlaceholderText = "Password";
            textBoxAuthUserPassword.Size = new Size(303, 33);
            textBoxAuthUserPassword.TabIndex = 5;
            // 
            // checkBoxStayLoggedIn
            // 
            checkBoxStayLoggedIn.AutoSize = true;
            checkBoxStayLoggedIn.FlatStyle = FlatStyle.Flat;
            checkBoxStayLoggedIn.Location = new Point(189, 122);
            checkBoxStayLoggedIn.Name = "checkBoxStayLoggedIn";
            checkBoxStayLoggedIn.Size = new Size(146, 29);
            checkBoxStayLoggedIn.TabIndex = 6;
            checkBoxStayLoggedIn.Text = "stay logged in";
            checkBoxStayLoggedIn.UseVisualStyleBackColor = true;
            // 
            // buttonAuthOk
            // 
            buttonAuthOk.BackColor = Color.SkyBlue;
            buttonAuthOk.FlatAppearance.BorderSize = 0;
            buttonAuthOk.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            buttonAuthOk.FlatStyle = FlatStyle.Flat;
            buttonAuthOk.Location = new Point(64, 167);
            buttonAuthOk.Name = "buttonAuthOk";
            buttonAuthOk.Size = new Size(217, 42);
            buttonAuthOk.TabIndex = 4;
            buttonAuthOk.Text = "Ok";
            buttonAuthOk.UseVisualStyleBackColor = false;
            buttonAuthOk.Click += buttonAuthOk_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(linkLabelPolicy);
            tabPage2.Controls.Add(checkBoxPolicy);
            tabPage2.Controls.Add(textBoxRegUserLogin);
            tabPage2.Controls.Add(textBoxRegUserPassword);
            tabPage2.Controls.Add(buttonRegOk);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(344, 235);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Registration";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabelPolicy
            // 
            linkLabelPolicy.AutoSize = true;
            linkLabelPolicy.Location = new Point(261, 124);
            linkLabelPolicy.Name = "linkLabelPolicy";
            linkLabelPolicy.Size = new Size(61, 25);
            linkLabelPolicy.TabIndex = 4;
            linkLabelPolicy.TabStop = true;
            linkLabelPolicy.Text = "Policy";
            linkLabelPolicy.Click += linkLabelPolicy_Click;
            // 
            // checkBoxPolicy
            // 
            checkBoxPolicy.AutoSize = true;
            checkBoxPolicy.FlatStyle = FlatStyle.Flat;
            checkBoxPolicy.Location = new Point(185, 122);
            checkBoxPolicy.Name = "checkBoxPolicy";
            checkBoxPolicy.Size = new Size(83, 29);
            checkBoxPolicy.TabIndex = 3;
            checkBoxPolicy.Text = "accept";
            checkBoxPolicy.UseVisualStyleBackColor = true;
            // 
            // textBoxRegUserLogin
            // 
            textBoxRegUserLogin.Location = new Point(21, 30);
            textBoxRegUserLogin.Name = "textBoxRegUserLogin";
            textBoxRegUserLogin.PlaceholderText = "Username";
            textBoxRegUserLogin.Size = new Size(303, 33);
            textBoxRegUserLogin.TabIndex = 0;
            textBoxRegUserLogin.Enter += textBoxRegUserName_Enter;
            // 
            // textBoxRegUserPassword
            // 
            textBoxRegUserPassword.Location = new Point(21, 83);
            textBoxRegUserPassword.Name = "textBoxRegUserPassword";
            textBoxRegUserPassword.PasswordChar = '*';
            textBoxRegUserPassword.PlaceholderText = "Password";
            textBoxRegUserPassword.Size = new Size(303, 33);
            textBoxRegUserPassword.TabIndex = 1;
            textBoxRegUserPassword.Enter += textBoxRegUserPassword_Enter;
            // 
            // errorProviderReg
            // 
            errorProviderReg.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProviderReg.ContainerControl = this;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(377, 302);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AuthForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderReg).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonRegOk;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBoxRegUserPassword;
        private TextBox textBoxRegUserLogin;
        private TextBox textBoxAuthUserLogin;
        private TextBox textBoxAuthUserPassword;
        private CheckBox checkBoxStayLoggedIn;
        private Button buttonAuthOk;
        private CheckBox checkBoxPolicy;
        private LinkLabel linkLabelPolicy;
        private ErrorProvider errorProviderReg;
    }
}