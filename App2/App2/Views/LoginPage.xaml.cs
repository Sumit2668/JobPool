using App2.Helper;
using App2.StaticMethod;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.API;
using App2.Models;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        JobPoolAPI api = new JobPoolAPI();
        bool? ischeked = null;

        public LoginPage()
        {
            InitializeComponent();
            if (IMGCheck.Source == null)
            {
                IMGCheck.Source = "ic_check_box_outline";
                ischeked = false;
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // _isBack = true;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (txtPass.IsPassword == true)
            {
                txtPass.IsPassword = false;
                signupPassshow.Source = "icon_eye_on";
            }
            else
            {
                txtPass.IsPassword = true;
                signupPassshow.Source = "icon_eye_off";
            }
        }

        private void OnPassShowTepped(object sender, EventArgs e)
        {
            if (txtPass.IsPassword == true)
            {
                txtPass.IsPassword = false;
                signupPassshow.Source = "icon_eye_on";
            }
            else
            {
                txtPass.IsPassword = true;
                signupPassshow.Source = "icon_eye_off";
            }
        }


        void HandlePassword_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            txtPass.Placeholder = "Password (Minimum 6 Characters) *";//"Password"; PM 18-2-2017
            lblPass.IsVisible = false;
        }

        async void HandlePassword_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Task.Delay(100);
            SetPlaceHolderColor();
            txtPass.Placeholder = string.Empty;
            lblPass.IsVisible = true;
        }

        void EmailHandle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SetPlaceHolderColor();
            //txtEmail.Placeholder = "Email *";
            //lblEmail.IsVisible = false;
        }

        async void EmailHandle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Task.Delay(100);
            SetPlaceHolderColor();
            //txtEmail.Placeholder = string.Empty;
            //lblEmail.IsVisible = true;
        }

        void FNameHandle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            txtFName.Placeholder = "First Name *";
            lblFName.IsVisible = false;
            SetPlaceHolderColor();
        }

        async void FNameHandle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Task.Delay(100);
            txtFName.Placeholder = string.Empty;
            lblFName.IsVisible = true;
            SetPlaceHolderColor();

        }

        private void SetPlaceHolderColor()
        {
            //txtPass.TextColor = txtEmail.TextColor = Color.Black;
            //txtPass.PlaceholderColor = txtEmail.PlaceholderColor = txtFName.PlaceholderColor = txtLName.PlaceholderColor = Color.FromHex("#9B9B9B");
            lblPassError.IsVisible = lblMessage.IsVisible = false;
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

        private async void OnlblWebsiteTepped(object sender, EventArgs args)
        {
            await PopupNavigation.PushAsync(new ForgatePass());
        }

        private void IMGCheck_Tapped(object sender, EventArgs e)
        {
            if (ischeked != true)
            {
                IMGCheck.Source = "ic_check_box";
                ischeked = true;
                StaticMethods.AndroidSnackBar("Check");
            }
            else
            {
                IMGCheck.Source = "ic_check_box_outline";
                ischeked = false;
                StaticMethods.AndroidSnackBar("UNCheck");
            }
        }

        private void RegisterNow_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() =>
            {

                if (Application.Current.MainPage.Width > 0)
                {
                    var calcScreenWidth = Application.Current.MainPage.Width;
                    ImgLogo.WidthRequest = calcScreenWidth / 2 + 40;
                    btnLogin.WidthRequest = calcScreenWidth / 2 - 20;
                }
            });
        }

        private bool Validate()
        {
            string strError = string.Empty;
            bool isEmailPwdEmpty = false;
            bool isError = true;
            txtPass.PlaceholderColor = txtFName.PlaceholderColor = Color.Red;
            if (string.IsNullOrEmpty(txtFName.Text) && string.IsNullOrEmpty(txtPass.Text))
            {
                isEmailPwdEmpty = true;
                isError = false;
            }

            else if (string.IsNullOrEmpty(txtFName.Text))
            {
                TimeSpan.FromMilliseconds(250);
                isEmailPwdEmpty = true;
                isError = false;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                isEmailPwdEmpty = true;
                isError = false;
            }
            else if (!(Regex.IsMatch(txtFName.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))) && !(Regex.IsMatch(txtPass.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtFName.TextColor = txtPass.TextColor = Color.Red;
                strError = "Please enter valid credentials";
                isError = false;
            }
            else if (!(Regex.IsMatch(txtFName.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtFName.TextColor = Color.Red;
                strError = "Please enter valid Email";
                isError = false;
            }
            else if (!(Regex.IsMatch(txtPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
            {
                txtPass.TextColor = Color.Red;
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

        public void SaveData()
        {
            string Email, Password;
            Email = Convert.ToString(txtFName.Text);
            Password = Convert.ToString(txtPass.Text);
            api.postLogin(Email, Password);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                LoginProcess();
            }
        }

        private void LoginProcess()
        {
            JobPoolAPI api = null;
            ResponseModel usermodel = null;
            Device.BeginInvokeOnMainThread(async() =>
            {
                try
                {
                    api = new JobPoolAPI();
                    Loader.IsVisible = true; Loader.IsRunning = true;
                    usermodel = api.postLogin(txtFName.Text, txtPass.Text);
                    if (usermodel.Success == "1")
                    {
                        StaticMethods.SaveLocalData(usermodel);
                        await PopupNavigation.PushAsync(new Successfully(usermodel.Message));
                    }
                    Loader.IsVisible = false; Loader.IsRunning = false;
                }
                catch
                {
                    ShowMessage("Failed to Authenticate user login", Color.Red);
                }
            });
        }

    }
}
