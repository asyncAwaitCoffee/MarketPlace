using MarketPlaceLibrary;
using System.Data.Common;
using System.Diagnostics;

namespace MarketPlaceUI
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void buttonRegOk_Click(object sender, EventArgs e)
        {
            errorProviderReg.Clear();

            if (!checkBoxPolicy.Checked)
            {
                MessageBox.Show("Before proceed you need to accept the Policy.");
                return;
            }

            if (textBoxRegUserName.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxRegUserName, "Hey!");
            }

            if (textBoxRegUserPassword.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxRegUserPassword, "Hey!");
            }

            if (errorProviderReg.HasErrors)
            {
                return;
            }

            int success = 0;

            try
            {
                success = await DataAccess.SaveUserToDB(textBoxRegUserName.Text, textBoxRegUserPassword.Text);
            }
            catch (DbException ex)
            {
                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        MessageBox.Show("This name is already in use");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try another user name.");
                // TODO - log
            }

            if (success == 1)
            {
                MessageBox.Show("You successfully registered!");
            }

        }

        private void textBoxRegUserName_Enter(object sender, EventArgs e)
        {
            errorProviderReg.SetError(textBoxRegUserName, "");
        }

        private void textBoxRegUserPassword_Enter(object sender, EventArgs e)
        {
            errorProviderReg.SetError(textBoxRegUserPassword, "");
        }

        private void buttonAuthOk_Click(object sender, EventArgs e)
        {
            errorProviderReg.Clear();

            if (!checkBoxPolicy.Checked)
            {
                MessageBox.Show("Before proceed you need to accept the Policy.");
                return;
            }

            if (textBoxRegUserName.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxAuthUserName, "Hey!");
            }

            if (textBoxRegUserPassword.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxAuthPassword, "Hey!");
            }

            if (errorProviderReg.HasErrors)
            {
                return;
            }
        }
    }
}
