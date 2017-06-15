using App2.API;
using App2.Helper;
using App2.Models;
using App2.StaticMethod;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : PopupPage
    {
        JobPoolAPI api = new JobPoolAPI();
        public ChangePassword()
        {
            InitializeComponent();
        }
        
        private async void txtEmailID_Focused(object sender, EventArgs e)
        {
            await Task.Delay(100);
            txtEmailID.Placeholder = string.Empty;
            lblEmailID.IsVisible = true;
            
        }

        private void txtEmailID_Unfocused(object sender, EventArgs e)
        {
            txtEmailID.Placeholder = "Enter Email Id";
            lblEmailID.IsVisible = false;
        }
        private async void btnChangePass_Clicked(object sender, EventArgs e)
        {
            ResponseModel usermodel = null;
            if (Validate())
            {
                usermodel= api.postChangePassword(txtEmailID.Text, txtOldPass.Text, txtNewPass.Text);
                await PopupNavigation.PushAsync(new Successfully(usermodel.Message));
            }
        }
        
        private void NewPassword_Tapped(object sender, EventArgs e)
        {
            if (txtNewPass.IsPassword == true)
            {
                txtNewPass.IsPassword = false;
                signupPassshow.Source = "icon_eye_on";
            }
            else
            {
                txtNewPass.IsPassword = true;
                signupPassshow.Source = "icon_eye_off";
            }
        }
        
        private  void OnOldPass_Tapped(object sender, EventArgs e)
        {
            if (txtOldPass.IsPassword == true)
            {
                txtOldPass.IsPassword = false;
                imgOldPass.Source = "icon_eye_on";
            }
            else
            {
                txtOldPass.IsPassword = true;
                imgOldPass.Source = "icon_eye_off";
            }
        }

        private void NewPassword_Unfocused(object sender, EventArgs e)
        {
            txtNewPass.Placeholder = "New Password";
            lblNewPass.IsVisible = false;
        }
        private async void NewPassword_Focused(object sender, EventArgs e)
        {
            await Task.Delay(100);
            txtNewPass.Placeholder = string.Empty;
            lblNewPass.IsVisible = true;

        }
        private async void OldPassword_Focused(object sender, EventArgs e)
        {
            await Task.Delay(100);
            txtOldPass.Placeholder = string.Empty;
            lblOldPass.IsVisible = true;
         }
        private void OldPassword_Unfocused(object sender, EventArgs e)
        {
            txtOldPass.Placeholder = "Old Password";
            lblOldPass.IsVisible = false;
        }

        private bool Validate()
        {
            string strError = string.Empty;
            bool isEmailPwdEmpty = false;
            bool isError = true;
            txtEmailID.PlaceholderColor = txtEmailID.PlaceholderColor = Color.Red;
            if (string.IsNullOrEmpty(txtEmailID.Text) && string.IsNullOrEmpty(txtOldPass.Text))
            {
                isEmailPwdEmpty = true;
                isError = false;
            }

            else if (string.IsNullOrEmpty(txtOldPass.Text))
            {
                TimeSpan.FromMilliseconds(250);
                isEmailPwdEmpty = true;
                isError = false;
            }
           
            else if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                TimeSpan.FromMilliseconds(250);
                isEmailPwdEmpty = true;
                isError = false;
            }
            else if (!(Regex.IsMatch(txtEmailID.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))) 
                  && !(Regex.IsMatch(txtOldPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                  && !(Regex.IsMatch(txtNewPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtEmailID.TextColor = txtNewPass.TextColor = txtOldPass.TextColor = Color.Red;
                strError = "Please enter valid credentials";
                isError = false;
            }
            else if (!(Regex.IsMatch(txtEmailID.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtEmailID.TextColor = Color.Red;
                strError = "Please enter valid Email";
                isError = false;
            }
            else if (!(Regex.IsMatch(txtNewPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtNewPass.TextColor = Color.Red;
                strError = "";
                isError = false;
                lblPassError.Text = "• Must be at least 6 characters long." + Environment.NewLine
                    + "• Maximum character limit is 15 characters";
                lblPassError.IsVisible = true;
                return isError;
               }
            else if (!(Regex.IsMatch(txtOldPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtOldPass.TextColor = Color.Red;
                strError = "";
                isError = false;
                lblPassError.Text = "• Must be at least 6 characters long." + Environment.NewLine
                    + "• Maximum character limit is 15 characters";
                lblPassError.IsVisible = true;
                return isError;
            }
            if (!isError && !isEmailPwdEmpty)
            {
                ShowMessage(strError, Color.Red);
            }
            return isError;
        }
        private void ShowMessage(string strMessage, Color color)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                lblMessage.Text = strMessage;
                lblMessage.TextColor = color;
                lblMessage.IsVisible = true;
                Device.StartTimer(TimeSpan.FromSeconds(5), () => { lblMessage.IsVisible = false; return false; });
            });
        }
    }
}
