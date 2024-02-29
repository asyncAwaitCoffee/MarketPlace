namespace MarketPlaceUI
{
    partial class AccountForm
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
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            tableLayoutPanelAccountControls = new TableLayoutPanel();
            errorProviderAccount = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderAccount).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(30, 34);
            textBoxName.Margin = new Padding(5);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Name";
            textBoxName.Size = new Size(239, 33);
            textBoxName.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(30, 89);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Size = new Size(239, 33);
            textBoxEmail.TabIndex = 1;
            // 
            // tableLayoutPanelAccountControls
            // 
            tableLayoutPanelAccountControls.ColumnCount = 2;
            tableLayoutPanelAccountControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAccountControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelAccountControls.Location = new Point(49, 156);
            tableLayoutPanelAccountControls.Name = "tableLayoutPanelAccountControls";
            tableLayoutPanelAccountControls.RowCount = 1;
            tableLayoutPanelAccountControls.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelAccountControls.Size = new Size(200, 36);
            tableLayoutPanelAccountControls.TabIndex = 2;
            // 
            // errorProviderAccount
            // 
            errorProviderAccount.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProviderAccount.ContainerControl = this;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(298, 224);
            Controls.Add(tableLayoutPanelAccountControls);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "AccountForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AccountForm";
            ((System.ComponentModel.ISupportInitialize)errorProviderAccount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TableLayoutPanel tableLayoutPanelAccountControls;
        private ErrorProvider errorProviderAccount;
    }
}