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
            buttonOk = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            tabPage2 = new TabPage();
            linkLabelPolicy = new LinkLabel();
            checkBoxPolicy = new CheckBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(64, 167);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(217, 42);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
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
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(344, 235);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Authorization";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(21, 30);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Username";
            textBox3.Size = new Size(303, 33);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(21, 83);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.PlaceholderText = "Password";
            textBox4.Size = new Size(303, 33);
            textBox4.TabIndex = 5;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Location = new Point(189, 122);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(135, 29);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "stay loged in";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(64, 167);
            button1.Name = "button1";
            button1.Size = new Size(217, 42);
            button1.TabIndex = 4;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(linkLabelPolicy);
            tabPage2.Controls.Add(checkBoxPolicy);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(buttonOk);
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
            // textBox2
            // 
            textBox2.Location = new Point(21, 30);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Username";
            textBox2.Size = new Size(303, 33);
            textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, 83);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.PlaceholderText = "Password";
            textBox1.Size = new Size(303, 33);
            textBox1.TabIndex = 1;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
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
            ResumeLayout(false);
        }

        #endregion
        private Button buttonOk;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private CheckBox checkBox1;
        private Button button1;
        private CheckBox checkBoxPolicy;
        private LinkLabel linkLabelPolicy;
    }
}