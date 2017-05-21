using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo : ContentPage
    {
        public Demo()
        {
            InitializeComponent();
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

        async void Signup_Clicked(object sender, System.EventArgs e)
        {
            //try
            //{
            //    StaticMethods.ShowLoader();
            //    HelperClass.btnRipple(sender as Button);
            //    btnSignup.Clicked -= Signup_Clicked;
            //    //ShowErrorIndicatior();
            //    if (Validate())
            //    {


            //        await Task.Factory.StartNew(() =>
            //        {
            //            SignUpProcess();
            //        });
            //    }
            //}

            //catch (Exception ex)
            //{
            //    //StaticMethods.ShowToast(ex.Message);
            //    ShowMessage(ex.Message, Color.Red);
            //}
            //finally
            //{
            //    StaticMethods.DismissLoader();
            //    btnSignup.Clicked += Signup_Clicked;
            //}
        }

        //public SignupClass GetSignupDetails()
        //{
        //    SignupClass signupobj = new SignupClass();

        //    signupobj.Password = txtPass.Text;
        //    signupobj.DeviceType = HelperClass.getDeviceType();
        //    signupobj.SocialType = "Web";
        //    signupobj.IsDevice = 1;
        //    signupobj.DeviceID = HelperClass.getDeviceidentifier();
        //    signupobj.UserSocialID = "";
        //    signupobj.Email = txtEmail.Text;
        //    signupobj.FirstName = txtFName.Text;
        //    signupobj.LastName = txtLName.Text;
        //    signupobj.Token = "";

        //    return signupobj;
        //}

        //private void SignUpProcess()
        //{
        //    ResponseModel response = null;
        //    APIClass api = new APIClass();
        //    SignupClass signup_formdatamodel = null;
        //    try
        //    {
        //        signup_formdatamodel = GetSignupDetails();
        //        response = api.postsignup(signup_formdatamodel);

        //        if (response.ResponseCode == 200 || response.ResponseCode == 201)
        //        {
        //            ShowMessage(response.Message + " " + signup_formdatamodel.Email, Color.Green);
        //            LoginProcess(signup_formdatamodel);
        //        }
        //        else if (response.ResponseCode == 511)
        //        {
        //            // StaticMethods.ShowToast("Sorry this email has already been taken");

        //            ShowMessage("Sorry this email has already been taken", Color.Red);
        //        }
        //        else
        //        {
        //            ShowMessage(response.Message, Color.Red);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(ex.Message, Color.Red);
        //    }
        //}

        //private void LoginProcess(SignupClass signup_formdatamodel)
        //{
        //    LoginClass loginObj = new LoginClass();
        //    UserModel usermodel = null;
        //    APIClass api = new APIClass();
        //    try
        //    {
        //        loginObj.Password = signup_formdatamodel.Password;
        //        loginObj.DeviceType = signup_formdatamodel.DeviceType;
        //        loginObj.Username = signup_formdatamodel.Email;
        //        loginObj.IsDevice = 1;
        //        loginObj.DeviceID = signup_formdatamodel.DeviceID;
        //        usermodel = api.PostLogin(loginObj);

        //        if (usermodel.ResponseCode == 200)
        //        {
        //            usermodel.IsSignup = false;
        //            StaticMethods.SaveLocalData(usermodel);
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                Navigation.PushAsync(new SportsSconnPage(usermodel));
        //            });
        //        }
        //        else
        //        {
        //            //StaticMethods.ShowToast(usermodel.Message);
        //            ShowMessage(usermodel.Message, Color.Red);
        //        }
        //    }
        //    catch
        //    {
        //        // StaticMethods.ShowToast("Signup process failed");
        //        ShowMessage("Signup process failed", Color.Red);
        //    }
        //    finally
        //    {
        //        loginObj = null;
        //        api = null;
        //        signup_formdatamodel = null;
        //    }
        //}

        //private bool Validate()
        //{
        //    string strError = string.Empty;
        //    bool isEmailPwdEmpty = false;
        //    bool isError = true;
        //    txtLName.PlaceholderColor = txtFName.PlaceholderColor = txtPass.PlaceholderColor = txtEmail.PlaceholderColor = Color.Red;
        //    if (string.IsNullOrEmpty(txtFName.Text) && string.IsNullOrEmpty(txtLName.Text) &&
        //        string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPass.Text))
        //    {
        //        isEmailPwdEmpty = true;
        //        isError = false;
        //    }
        //    else if (string.IsNullOrEmpty(txtEmail.Text))
        //    {
        //        isEmailPwdEmpty = true;
        //        isError = false;
        //    }
        //    else if (string.IsNullOrEmpty(txtPass.Text))
        //    {
        //        isEmailPwdEmpty = true;
        //        isError = false;
        //    }
        //    if (string.IsNullOrEmpty(txtFName.Text))
        //    {
        //        isEmailPwdEmpty = true;
        //        isError = false;
        //    }
        //    else if (string.IsNullOrEmpty(txtLName.Text))
        //    {
        //        isEmailPwdEmpty = true;
        //        isError = false;
        //    }
        //    else if (!(Regex.IsMatch(txtEmail.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))) && !(Regex.IsMatch(txtPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
        //    {
        //        txtPass.TextColor = txtEmail.TextColor = Color.Red;
        //        strError = "Please enter valid credentials";
        //        isError = false;
        //    }
        //    else if (!(Regex.IsMatch(txtEmail.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
        //    {
        //        txtEmail.TextColor = Color.Red;
        //        strError = "Please enter valid Email";
        //        isError = false;
        //    }

        //    else if (!(Regex.IsMatch(txtPass.Text, HelperClass.passwordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
        //    {
        //        txtPass.TextColor = Color.Red;
        //        strError = "";
        //        isError = false;
        //        lblPassError.Text = "• Must be at least 6 characters long." + Environment.NewLine
        //            + "• Must be a combination of alpha-numeric and special characters." + Environment.NewLine
        //            + "• Maximum character limit is 15 characters"
        //            ;
        //        lblPassError.IsVisible = true;
        //        return isError;
        //    }

        //    if (!isError && !isEmailPwdEmpty)
        //    {
        //        ShowMessage(strError, Color.Red);
        //    }
        //    return isError;
        //}

        //private void ShowErrorIndicatior()
        //{
        //	IsValidForm = true;
        //	txtFName.PlaceholderColor = Color.Red;
        //	txtLName.PlaceholderColor = Color.Red;
        //	txtEmail.PlaceholderColor = Color.Red;
        //	txtPass.PlaceholderColor = Color.Red;

        //	if (String.IsNullOrEmpty(txtFName.Text) && String.IsNullOrEmpty(txtLName.Text) && 
        //	    String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtPass.Text))
        //	{
        //		StaticMethods.ShowToast("All fields are required.");
        //		IsValidForm = false;
        //	}
        //	else
        //	{
        //		if (String.IsNullOrEmpty(txtFName.Text))
        //		{
        //			txtFName.PlaceholderColor = Color.Red;
        //			StaticMethods.ShowToast("First Name is required.");
        //			IsValidForm = false;
        //		}
        //		else if (String.IsNullOrEmpty(txtLName.Text))
        //		{
        //			txtLName.PlaceholderColor = Color.Red;
        //			StaticMethods.ShowToast("Last Name is required.");
        //			IsValidForm = false;
        //		}
        //		else if (String.IsNullOrEmpty(txtEmail.Text))
        //		{
        //			txtEmail.PlaceholderColor = Color.Red;
        //			StaticMethods.ShowToast("Email is required.");
        //			IsValidForm = false;
        //		}
        //		else if (String.IsNullOrEmpty(txtPass.Text))
        //		{
        //			txtPass.PlaceholderColor = Color.Red;
        //			StaticMethods.ShowToast("Password is required.");
        //			IsValidForm = false;
        //		}
        //		else
        //		{
        //			if (!String.IsNullOrEmpty(txtEmail.Text) && !(Regex.IsMatch(txtEmail.Text, HelperClass.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))))
        //			{
        //				txtEmail.PlaceholderColor = Color.Red;
        //				StaticMethods.ShowToast("Please enter valid email.");
        //				IsValidForm = false;
        //			}
        //			else if (!String.IsNullOrEmpty(txtPass.Text) && !(Regex.IsMatch(txtPass.Text, HelperClass.passwordRegex)))
        //			{
        //				txtPass.PlaceholderColor = Color.Red;
        //				StaticMethods.ShowToast("Password must contain atleat 8 characters, including Upper/lowercase/numbers and special characters $@$!% *#?& ");
        //				IsValidForm = false;
        //			}
        //		}
        //	}
        //}


        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            txtPass.TextColor = Color.Black;
        }

        async void SocialFB_Tapped(object sender, System.EventArgs e)
        {
            //SocialProviderName = EnumMaster.Social.Facebook.ToString();
            //await Navigation.PushModalAsync(new ProviderLoginPage(SocialProviderName));
        }

        async void SocialTW_Tapped(object sender, System.EventArgs e)
        {
            //SocialProviderName = EnumMaster.Social.Twitter.ToString();
            //await Navigation.PushModalAsync(new ProviderLoginPage(SocialProviderName));
        }

        async void SocialGoogle_Tapped(object sender, System.EventArgs e)
        {
            //SocialProviderName = EnumMaster.Social.Google.ToString();
            //await Navigation.PushModalAsync(new ProviderLoginPage(SocialProviderName));
        }

        async void SocialLIn_Tapped(object sender, System.EventArgs e)
        {
            //SocialProviderName = EnumMaster.Social.Linkdn.ToString();
            //await Navigation.PushModalAsync(new ProviderLoginPage(SocialProviderName));
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
            txtEmail.Placeholder = "Email *";
            lblEmail.IsVisible = false;
        }

        async void EmailHandle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Task.Delay(100);
            SetPlaceHolderColor();
            txtEmail.Placeholder = string.Empty;
            lblEmail.IsVisible = true;
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

        void LNameHandle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            txtLName.Placeholder = "Last Name *";
            lblLName.IsVisible = false;
            SetPlaceHolderColor();
        }

        async void LNameHandle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await Task.Delay(100);
            SetPlaceHolderColor();
            txtLName.Placeholder = string.Empty;
            lblLName.IsVisible = true;
        }
        private void SetPlaceHolderColor()
        {
            txtPass.TextColor = txtEmail.TextColor = Color.Black;
            txtPass.PlaceholderColor = txtEmail.PlaceholderColor = txtFName.PlaceholderColor = txtLName.PlaceholderColor = Color.FromHex("#9B9B9B");
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

        private void OnlblWebsiteTepped(object sender, EventArgs args)
        {
            //Uri uri = new Uri((new APIClass()).TermAndCondition());
            //Device.OpenUri(uri);
        }
    }
}
