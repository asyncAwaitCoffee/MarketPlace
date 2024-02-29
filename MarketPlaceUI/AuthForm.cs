﻿using MarketPlaceLibrary;
using MarketPlaceLibrary.Models;
using System.Data.Common;
using System.Diagnostics;

namespace MarketPlaceUI
{
    public partial class AuthForm : Form
    {
        private Label _labelLogin;
        public AuthForm(Label labelLogin)
        {
            InitializeComponent();
            _labelLogin = labelLogin;
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

            try
            {
                (userId, userLevel) = await DataAccess.TryUserLogin(textBoxAuthUserLogin.Text, textBoxAuthUserPassword.Text);
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

                User.Init((int)userId, textBoxAuthUserLogin.Text, (int)userLevel!);
                _labelLogin.Text = textBoxAuthUserLogin.Text;

                if (checkBoxStayLoggedIn.Checked)
                {
                    // TODO - better checkBoxStayLoggedIn
                    await File.WriteAllLinesAsync("./stay_logged_in.txt", [userId.ToString(), textBoxAuthUserLogin.Text, userLevel.ToString()]);
                }

                MessageBox.Show("You successfully logged in!");

                Close();
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
