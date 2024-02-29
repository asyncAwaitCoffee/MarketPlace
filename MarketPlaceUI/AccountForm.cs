using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using MarketPlaceUI.FormsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketPlaceUI
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            LoadData();
            AddControls();

            textBoxEmail.Enter += ErrorProviderReset;
        }

        private async void LoadData()
        {
            Person? person = await DataAccess.GetUserPersonData(User.Instance().Id);

            if (person != null)
            {
                textBoxName.Text = person.Name;
                textBoxEmail.Text = person.Email;
            }
        }
        private void AddControls()
        {
            Button buttonConfirm = ButtonFactory.BuildButton("buttonConfirm", ButtonSize.Medium, new Point(0, 0), text: "Confirm", dockStyle: DockStyle.Left);
            Button buttonCancel = ButtonFactory.BuildButton("buttonCancel", ButtonSize.Medium, new Point(0, 0), text: "Cancel", dockStyle: DockStyle.Right);
            
            buttonConfirm.Click += ButtonConfirm_Click;
            buttonCancel.Click += ButtonCancel_Click;

            tableLayoutPanelAccountControls.Controls.Add(buttonConfirm);
            tableLayoutPanelAccountControls.Controls.Add(buttonCancel);
        }

        private void ButtonCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private async void ButtonConfirm_Click(object? sender, EventArgs e)
        {
            errorProviderAccount.Clear();

            string personName = textBoxName.Text;
            string email = textBoxEmail.Text;

            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                errorProviderAccount.SetError(textBoxEmail, "Email address is incorrect.");
            }

            if (errorProviderAccount.HasErrors)
            {
                return;
            }

            await DataAccess.UpdateUserPersonData(User.Instance().Id, personName, email);

            MessageBox.Show("Personal data updated.");

            this.Close();
        }

        private void ErrorProviderReset(object sender, EventArgs e)
        {
            errorProviderAccount.SetError((Control)(sender), "");
        }
    }
}
