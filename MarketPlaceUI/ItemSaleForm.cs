using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.FormsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketPlaceUI
{
    public partial class ItemSaleForm : Form
    {
        private string imagePath = "";
        public ItemSaleForm()
        {
            InitializeComponent();

            textBoxItemPriceStart.KeyPress += textBoxDecimalValidation;
            textBoxItemPriceEnd.KeyPress += textBoxDecimalValidation;
            textBoxItemBidStep.KeyPress += textBoxDecimalValidation;

            textBoxItemTitle.Enter += ErrorProviderReset;
            comboBoxItemCategory.Enter += ErrorProviderReset;
            textBoxItemPriceStart.Enter += ErrorProviderReset;
            textBoxItemPriceEnd.Enter += ErrorProviderReset;
            textBoxItemBidStep.Enter += ErrorProviderReset;
            dateTimePickerAuctionEndDate.Enter += ErrorProviderReset;

            AddControls();
        }

        private void AddControls()
        {
            Button buttonImageAdd = ButtonFactory.BuildButton("buttonImageAdd", ButtonSize.Medium, new Point(0, 0), text: "Add image", dockStyle: DockStyle.Fill);
            buttonImageAdd.Click += buttonImageAdd_Click;

            Button buttonItemConfirm = ButtonFactory.BuildButton("buttonItemConfirm", ButtonSize.Medium, new Point(0, 0), text: "Confirm Sale", dockStyle: DockStyle.Fill);
            buttonItemConfirm.Click += buttonItemConfirm_Click;

            panelDetailsButton.Controls.Add(buttonImageAdd);
            panelFormButton.Controls.Add(buttonItemConfirm);

            void buttonImageAdd_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;

                    
                }
            }

            async void buttonItemConfirm_Click(object sender, EventArgs e)
            {
                errorProviderAddItem.Clear();

                // TODO - global const
                if (textBoxItemTitle.Text.Length < 3)
                {
                    errorProviderAddItem.SetError(textBoxItemTitle, "Title should be at least 3 characters.");
                }

                // TODO - tag, value ??
                if (comboBoxItemCategory.Text.Length < 1)
                {
                    errorProviderAddItem.SetError(comboBoxItemCategory, "No category was selected.");
                }

                if (textBoxItemPriceStart.Text.Length < 1)
                {
                    errorProviderAddItem.SetError(textBoxItemPriceStart, "No price was entered.");
                }

                if (checkBoxIsAuction.Checked) {

                    if (textBoxItemPriceEnd.Text.Length < 1)
                    {
                        errorProviderAddItem.SetError(textBoxItemPriceEnd, "No price was entered.");
                    }
                    else if (decimal.Parse(textBoxItemPriceEnd.Text) <= decimal.Parse(textBoxItemPriceStart.Text))
                    {
                        errorProviderAddItem.SetError(textBoxItemPriceEnd, "End price can not be less or equal to start price.");
                    }

                    if (textBoxItemBidStep.Text.Length < 1)
                    {
                        errorProviderAddItem.SetError(textBoxItemBidStep, "No bid step was entered.");
                    }
                    else if (decimal.Parse(textBoxItemBidStep.Text) > (decimal.Parse(textBoxItemPriceEnd.Text) - decimal.Parse(textBoxItemPriceStart.Text)))
                    {
                        errorProviderAddItem.SetError(textBoxItemBidStep, "Consider smaller bid step. It should be less than the difference between the initial and final price.");
                    }

                    if (dateTimePickerAuctionEndDate.Value < DateTime.Now)
                    {
                        errorProviderAddItem.SetError(dateTimePickerAuctionEndDate, "The auction end date cannot be before the current date.");
                    }
                }                

                if (!errorProviderAddItem.HasErrors)
                {
                    int itemId;
                    if (checkBoxIsAuction.Checked)
                    {
                        itemId = await DataAccess.AddItemToMarket(
                            User.Instance().Id,
                            textBoxItemTitle.Text,
                            textBoxItemDescription.Text,
                            byte.Parse(comboBoxItemCategory.Text),
                            decimal.Parse(textBoxItemPriceStart.Text),
                            decimal.Parse(textBoxItemPriceEnd.Text),
                            decimal.Parse(textBoxItemBidStep.Text),
                            dateTimePickerAuctionEndDate.Value                            
                            );
                    }
                    else
                    {
                        itemId = await DataAccess.AddItemToMarket(
                            User.Instance().Id,
                            textBoxItemTitle.Text,
                            textBoxItemDescription.Text,
                            byte.Parse(comboBoxItemCategory.Text),
                            decimal.Parse(textBoxItemPriceStart.Text));
                    }

                    // TODO - message for no imagePath ??
                    if (imagePath.Length > 0 && File.Exists(imagePath))
                    {
                        DataAccess.SaveImageToDatabase(itemId, imagePath);
                    }
                    
                }
            }
        }

        private void checkBoxIsAuction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsAuction.Checked)
            {
                dateTimePickerAuctionEndDate.Enabled = true;
                textBoxItemPriceEnd.Enabled = true;
                textBoxItemBidStep.Enabled = true;
            }
            else
            {
                dateTimePickerAuctionEndDate.Enabled = false;
                textBoxItemPriceEnd.Enabled = false;
                textBoxItemBidStep.Enabled = false;
            }
        }

        private void textBoxDecimalValidation(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                MessageBox.Show("Only numbers are allowed. Use comma for decimal part.");
                e.Handled = true;
            }
        }
        private void ErrorProviderReset(object sender, EventArgs e)
        {
            errorProviderAddItem.SetError((Control)(sender), "");
        }

        
    }
}
