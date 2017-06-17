using App2.API;
using App2.Models;
using App2.StaticMethod;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CandidateReg : ContentPage
    {
        JobPoolAPI api = new JobPoolAPI();
        CandidateRegMdl crm = new CandidateRegMdl();
        ResponseModel responseMdl = new ResponseModel();
        Boolean ischkuotline = false;
        public CandidateReg()
        {
            InitializeComponent();
            if (IMGMaleCheck.Source != null)
            {
                ischkuotline = true;
            }
        }

        private void MaleCheck_Tapped(object sender, EventArgs e)
        {
            IMGMaleCheck.Source = "ic_check_box";
            IMGFemaleCheck.Source = "ic_check_box_outline";
            ischkuotline = true;
        }

        private void FeMaleCheck_Tapped(object sender, EventArgs e)
        {
                IMGFemaleCheck.Source = "ic_check_box";
                IMGMaleCheck.Source = "ic_check_box_outline";
                ischkuotline = false;
        }

        private async void txtname_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtname.Placeholder = string.Empty;
            lblname.IsVisible = true;
            SetPlaceHolderColor();
        }

        private void txtname_Unfocused(object sender, FocusEventArgs e)
        {
            txtname.Placeholder = "Name";
            lblname.IsVisible = false;
        }

        private async void txtuserid_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtuserid.Placeholder = string.Empty;
            lbluserid.IsVisible = true;
            SetPlaceHolderColor();
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

        private void txtuserid_Unfocused(object sender, FocusEventArgs e)
        {
            txtuserid.Placeholder = "User ID";
            lbluserid.IsVisible = false;
        }

        private async void txtemail_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtemail.Placeholder = string.Empty;
            lblemail.IsVisible = true;
            SetPlaceHolderColor();
        }

        private void txtemail_Unfocused(object sender, FocusEventArgs e)
        {
            txtemail.Placeholder = "Email";
            lblemail.IsVisible = false;
        }

        private async void txtPass_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtPass.Placeholder = string.Empty;
            lblPass.IsVisible = true;
            SetPlaceHolderColor();
        }

        private void txtPass_Unfocused(object sender, FocusEventArgs e)
        {
            txtPass.Placeholder = "Password";
            lblPass.IsVisible = false;
        }

        private async void txtphone_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtphone.Placeholder = string.Empty;
            lblphone.IsVisible = true;
            SetPlaceHolderColor();
        }

        private void txtphone_Unfocused(object sender, FocusEventArgs e)
        {
            txtphone.Placeholder = "Phone";
            lblphone.IsVisible = false;
        }

        private void SetPlaceHolderColor()
        {
            //txtPass.PlaceholderColor = txtEmail.PlaceholderColor = txtFName.PlaceholderColor = txtLName.PlaceholderColor = Color.FromHex("#9B9B9B");
            lblPassError.IsVisible = lblMessage.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SaveData();
            Navigation.PushModalAsync(new Candidate());
        }

        public void SaveData()
        {
            try
            {
                crm.EMAIL = Convert.ToString(txtname.Text);
                crm.UserID= Convert.ToString(txtuserid.Text);
                crm.NAME = Convert.ToString(txtemail.Text);
                crm.Password = Convert.ToString(txtPass.Text);
                crm.PHONE = Convert.ToString(txtphone.Text);
                if (ischkuotline==true)
                {
                    crm.GENDER = "Male";
                }
                else
                {
                    crm.GENDER = "Female";
                }
                api.postCandidateReg(crm);
                StaticMethods.ShowToast(responseMdl.MESSAGE);
            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                responseMdl = null;
                crm = null;
            }
        }

    }
}
