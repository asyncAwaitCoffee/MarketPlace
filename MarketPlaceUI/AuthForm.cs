using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using System.Data.Common;
using System.Diagnostics;

namespace MarketPlaceUI
{
    public partial class AuthorizationForm : Form
    {
        private Label _labelLogin;
        private Label _labelBalance;
        public AuthorizationForm(Label labelLogin, Label labelBalance)
        {
            InitializeComponent();
            _labelLogin = labelLogin;
            _labelBalance = labelBalance;
        }

        private async void buttonRegOk_Click(object sender, EventArgs e)
        {
            errorProviderReg.Clear();

            if (!checkBoxPolicy.Checked)
            {
                MessageBox.Show("Before proceed you need to accept the Policy.");
                return;
            }

            if (textBoxRegUserLogin.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxRegUserLogin, "Hey!");
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
                success = await DataAccess.SaveUserToDB(textBoxRegUserLogin.Text, textBoxRegUserPassword.Text);
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
            errorProviderReg.SetError(textBoxRegUserLogin, "");
        }

        private void textBoxRegUserPassword_Enter(object sender, EventArgs e)
        {
            errorProviderReg.SetError(textBoxRegUserPassword, "");
        }

        private async void buttonAuthOk_Click(object sender, EventArgs e)
        {
            errorProviderReg.Clear();

            if (textBoxAuthUserLogin.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxAuthUserLogin, "Hey!");
            }

            if (textBoxAuthUserPassword.Text.Length < 3)
            {
                errorProviderReg.SetError(textBoxAuthUserPassword, "Hey!");
            }

            if (errorProviderReg.HasErrors)
            {
                return;
            }

            int? userId = null, userLevel = null;
            decimal? balance = null;

            try
            {
                (userId, userLevel, balance) = await DataAccess.TryUserLogin(textBoxAuthUserLogin.Text, textBoxAuthUserPassword.Text);
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

            if (userId != null)
            {
                User.LogOut();

                User.Init((int)userId, textBoxAuthUserLogin.Text, (int)userLevel!, (decimal)balance!);
                // TODO - method for labels
                _labelLogin.Text = textBoxAuthUserLogin.Text;
                _labelBalance.Text = $"{balance}$";
                _labelBalance.Left = _labelBalance.Parent.Width / 2 - _labelBalance.Width / 2;
                _labelLogin.Left = _labelLogin.Parent.Width / 2 - _labelLogin.Width / 2;

                if (checkBoxStayLoggedIn.Checked)
                {
                    // TODO - better checkBoxStayLoggedIn
                    await File.WriteAllLinesAsync("./stay_logged_in.txt", [userId.ToString(), textBoxAuthUserLogin.Text, userLevel.ToString()]);
                }

                MessageBox.Show("You successfully logged in!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Such login and password pair does not exist.");
            }


        }

        private void linkLabelPolicy_Click(object sender, EventArgs e)
        {
            // TODO - policy
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.google.com",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }
    }
}
