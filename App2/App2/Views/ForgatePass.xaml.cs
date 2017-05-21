using App2.API;
using App2.Helper;
using App2.StaticMethod;
using Rg.Plugins.Popup.Pages;
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
    public partial class ForgatePass : PopupPage
    {
        JobPoolAPI api = new JobPoolAPI();
        public ForgatePass()
        {
            InitializeComponent();
        }
        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(1);
        }

        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(0); ;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        
        private async void Email_Focused(object sender, EventArgs e)
        {
            await Task.Delay(100);
            txtEmail.Placeholder = string.Empty;
            lblMail.IsVisible = true;

        }
        private void Email_Unfocused(object sender, EventArgs e)
        {
            txtEmail.Placeholder = "Name";
            lblMail.IsVisible = false;

        }

        private void btnForgate_Clicked(object sender, EventArgs e)
        {
            if(Validate())
            {
                //StaticMethods.AndroidSnackBar("SSS");
                string ForgatePass = Convert.ToString(txtEmail.Text);
                api.postForgetPass(ForgatePass);
            }
        }
        private bool Validate()
        {
            bool isError = true;
            string strError = string.Empty;
            try
            {
                        
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    strError = "Please enter Email";
                    isError = false;
                }
                else if (!(Regex.IsMatch(txtEmail.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
                {
                txtEmail.TextColor = Color.Red;
                strError = "Please enter valid Email";
                isError = false;
                }
                if (!isError )
                    {
                        ShowMessage(strError, Color.Red);
                    }
            }
            catch (Exception e)
            {

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
