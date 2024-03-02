namespace MarketPlaceUI
{
    partial class ItemSaleForm
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
            textBoxItemTitle = new TextBox();
            textBoxItemDescription = new TextBox();
            comboBoxItemCategory = new ComboBox();
            textBoxItemPriceStart = new TextBox();
            textBoxItemPriceEnd = new TextBox();
            checkBoxIsAuction = new CheckBox();
            groupBoxItemDetails = new GroupBox();
            panelDetailsButton = new Panel();
            groupBoxItemPrice = new GroupBox();
            dateTimePickerAuctionEndDate = new DateTimePicker();
            textBoxItemBidStep = new TextBox();
            panelFormButton = new Panel();
            errorProviderAddItem = new ErrorProvider(components);
            groupBoxItemDetails.SuspendLayout();
            groupBoxItemPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderAddItem).BeginInit();
            SuspendLayout();
            // 
            // textBoxItemTitle
            // 
            textBoxItemTitle.Location = new Point(22, 43);
            textBoxItemTitle.Margin = new Padding(5);
            textBoxItemTitle.Name = "textBoxItemTitle";
            textBoxItemTitle.PlaceholderText = "Title";
            textBoxItemTitle.Size = new Size(267, 33);
            textBoxItemTitle.TabIndex = 0;
            // 
            // textBoxItemDescription
            // 
            textBoxItemDescription.Location = new Point(22, 85);
            textBoxItemDescription.MaxLength = 200;
            textBoxItemDescription.Multiline = true;
            textBoxItemDescription.Name = "textBoxItemDescription";
            textBoxItemDescription.PlaceholderText = "Description";
            textBoxItemDescription.Size = new Size(267, 170);
            textBoxItemDescription.TabIndex = 1;
            // 
            // comboBoxItemCategory
            // 
            comboBoxItemCategory.FormattingEnabled = true;
            comboBoxItemCategory.Items.AddRange(new object[] { "1", "2", "3" });
            comboBoxItemCategory.Location = new Point(22, 270);
            comboBoxItemCategory.Name = "comboBoxItemCategory";
            comboBoxItemCategory.Size = new Size(267, 33);
            comboBoxItemCategory.TabIndex = 2;
            // 
            // textBoxItemPriceStart
            // 
            textBoxItemPriceStart.Location = new Point(20, 85);
            textBoxItemPriceStart.Name = "textBoxItemPriceStart";
            textBoxItemPriceStart.PlaceholderText = "Price";
            textBoxItemPriceStart.Size = new Size(127, 33);
            textBoxItemPriceStart.TabIndex = 3;
            // 
            // textBoxItemPriceEnd
            // 
            textBoxItemPriceEnd.Enabled = false;
            textBoxItemPriceEnd.Location = new Point(182, 85);
            textBoxItemPriceEnd.Name = "textBoxItemPriceEnd";
            textBoxItemPriceEnd.PlaceholderText = "Max price";
            textBoxItemPriceEnd.Size = new Size(127, 33);
            textBoxItemPriceEnd.TabIndex = 4;
            // 
            // checkBoxIsAuction
            // 
            checkBoxIsAuction.AutoSize = true;
            checkBoxIsAuction.Location = new Point(182, 43);
            checkBoxIsAuction.Name = "checkBoxIsAuction";
            checkBoxIsAuction.Size = new Size(94, 29);
            checkBoxIsAuction.TabIndex = 5;
            checkBoxIsAuction.Text = "auction";
            checkBoxIsAuction.UseVisualStyleBackColor = true;
            checkBoxIsAuction.CheckedChanged += checkBoxIsAuction_CheckedChanged;
            // 
            // groupBoxItemDetails
            // 
            groupBoxItemDetails.Controls.Add(panelDetailsButton);
            groupBoxItemDetails.Controls.Add(textBoxItemTitle);
            groupBoxItemDetails.Controls.Add(textBoxItemDescription);
            groupBoxItemDetails.Controls.Add(comboBoxItemCategory);
            groupBoxItemDetails.Location = new Point(29, 12);
            groupBoxItemDetails.Name = "groupBoxItemDetails";
            groupBoxItemDetails.Size = new Size(328, 381);
            groupBoxItemDetails.TabIndex = 7;
            groupBoxItemDetails.TabStop = false;
            groupBoxItemDetails.Text = "Item Details";
            // 
            // panelDetailsButton
            // 
            panelDetailsButton.Location = new Point(163, 327);
            panelDetailsButton.Name = "panelDetailsButton";
            panelDetailsButton.Size = new Size(126, 38);
            panelDetailsButton.TabIndex = 3;
            // 
            // groupBoxItemPrice
            // 
            groupBoxItemPrice.Controls.Add(dateTimePickerAuctionEndDate);
            groupBoxItemPrice.Controls.Add(textBoxItemBidStep);
            groupBoxItemPrice.Controls.Add(checkBoxIsAuction);
            groupBoxItemPrice.Controls.Add(textBoxItemPriceStart);
            groupBoxItemPrice.Controls.Add(textBoxItemPriceEnd);
            groupBoxItemPrice.Location = new Point(381, 12);
            groupBoxItemPrice.Name = "groupBoxItemPrice";
            groupBoxItemPrice.Size = new Size(328, 255);
            groupBoxItemPrice.TabIndex = 8;
            groupBoxItemPrice.TabStop = false;
            groupBoxItemPrice.Text = "Sales Details";
            // 
            // dateTimePickerAuctionEndDate
            // 
            dateTimePickerAuctionEndDate.Enabled = false;
            dateTimePickerAuctionEndDate.Location = new Point(109, 189);
            dateTimePickerAuctionEndDate.Name = "dateTimePickerAuctionEndDate";
            dateTimePickerAuctionEndDate.Size = new Size(200, 33);
            dateTimePickerAuctionEndDate.TabIndex = 8;
            // 
            // textBoxItemBidStep
            // 
            textBoxItemBidStep.Enabled = false;
            textBoxItemBidStep.Location = new Point(182, 135);
            textBoxItemBidStep.Name = "textBoxItemBidStep";
            textBoxItemBidStep.PlaceholderText = "Bid";
            textBoxItemBidStep.Size = new Size(127, 33);
            textBoxItemBidStep.TabIndex = 6;
            // 
            // panelFormButton
            // 
            panelFormButton.Location = new Point(458, 325);
            panelFormButton.Name = "panelFormButton";
            panelFormButton.Size = new Size(180, 42);
            panelFormButton.TabIndex = 9;
            // 
            // errorProviderAddItem
            // 
            errorProviderAddItem.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProviderAddItem.ContainerControl = this;
            // 
            // ItemSaleForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(738, 411);
            Controls.Add(panelFormButton);
            Controls.Add(groupBoxItemPrice);
            Controls.Add(groupBoxItemDetails);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "ItemSaleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Item";
            groupBoxItemDetails.ResumeLayout(false);
            groupBoxItemDetails.PerformLayout();
            groupBoxItemPrice.ResumeLayout(false);
            groupBoxItemPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderAddItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxItemTitle;
        private TextBox textBoxItemDescription;
        private ComboBox comboBoxItemCategory;
        private TextBox textBoxItemPriceStart;
        private TextBox textBoxItemPriceEnd;
        private CheckBox checkBoxIsAuction;
        private GroupBox groupBoxItemDetails;
        private GroupBox groupBoxItemPrice;
        private DateTimePicker dateTimePickerAuctionEndDate;
        private TextBox textBoxItemBidStep;
        private Panel panelDetailsButton;
        private Panel panelFormButton;
        private ErrorProvider errorProviderAddItem;
    }
}