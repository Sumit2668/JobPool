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
    public partial class EmployeeRegister : ContentPage
    {
        JobPoolAPI api = new JobPoolAPI();
        EmployerRegMdl Erm = new EmployerRegMdl();
        ResponseModel responseMdl = new ResponseModel();
        Boolean ischeked = false;
        public EmployeeRegister()
        {
            InitializeComponent();
            if (IMGTerms.Source != null)
            {
                ischeked = true;
            }
        }

        private async void txtCompanyName_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtCompanyName.Placeholder = string.Empty;
            lblCompanyName.IsVisible = true;
        }

        private void txtCompanyName_Unfocused(object sender, FocusEventArgs e)
        {
            txtCompanyName.Placeholder = "COMPANY NAME";
            lblCompanyName.IsVisible = false;
        }

        private async void txtConPerson_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtConPerson.Placeholder = string.Empty;
            lblConPerson.IsVisible = true;
        }

        private void txtConPerson_Unfocused(object sender, FocusEventArgs e)
        {
            txtConPerson.Placeholder = "CONTACT PERSON";
            lblConPerson.IsVisible = false;

        }

        private async void txtEmail_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtEmail.Placeholder = string.Empty;
            lblEmail.IsVisible = true;
        }

        private void txtEmail_Unfocused(object sender, FocusEventArgs e)
        {
            txtEmail.Placeholder = "EMAIL";
            lblEmail.IsVisible = false;

        }

        private async void txtPhone_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtPhone.Placeholder = string.Empty;
            lblPhone.IsVisible = true;

        }

        private void txtPhone_Unfocused(object sender, FocusEventArgs e)
        {
            txtPhone.Placeholder = "PHONE";
            lblPhone.IsVisible = false;

        }

        private void txtPass_Unfocused(object sender, FocusEventArgs e)
        {
            txtPass.Placeholder = "PASSWORD";
            lblPass.IsVisible = false;

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

        private async void txtPass_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtPass.Placeholder = string.Empty;
            lblPass.IsVisible = true;
        }

        private async void txtCurRequi_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtCurRequi.Placeholder = string.Empty;
            lblCurRequi.IsVisible = true;
        }

        private void txtCurRequi_Unfocused(object sender, FocusEventArgs e)
        {
            txtCurRequi.Placeholder = "CURRENT REQUIRMENT";
            lblCurRequi.IsVisible = false;

        }

        private async void txtexeperiance_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtexeperiance.Placeholder = string.Empty;
            lblExepEriance.IsVisible = true;
        }

        private void txtexeperiance_Unfocused(object sender, FocusEventArgs e)
        {
            txtexeperiance.Placeholder = "EXPERIENCE";
            lblExepEriance.IsVisible = false;
        }

        private async void txtSkill_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtSkill.Placeholder = string.Empty;
            lblSkill.IsVisible = true;

        }

        private void txtSkill_Unfocused(object sender, FocusEventArgs e)
        {
            txtSkill.Placeholder = "SKILL";
            lblSkill.IsVisible = false;
        }

        private async void txtJobRoll_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtJobRoll.Placeholder = string.Empty;
            lblJobRoll.IsVisible = true;

        }

        private void txtJobRoll_Unfocused(object sender, FocusEventArgs e)
        {
            txtJobRoll.Placeholder = "JOB ROLL";
            lblJobRoll.IsVisible = false;
        }

        private async void txtlocation_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtlocation.Placeholder = string.Empty;
            lblLocation.IsVisible = true;

        }

        private void txtlocation_Unfocused(object sender, FocusEventArgs e)
        {
            txtlocation.Placeholder = "LOCATION";
            lblLocation.IsVisible = false;
        }

        private async void txtAddress_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtAddress.Placeholder = string.Empty;
            lblAddress.IsVisible = true;

        }

        private void txtAddress_Unfocused(object sender, FocusEventArgs e)
        {
            txtAddress.Placeholder = "ADDRESS";
            lblAddress.IsVisible = false;
        }

        private void Terms_Tapped(object sender, EventArgs e)
        {
            if (ischeked)
            {
                IMGTerms.Source = "ic_check_box";
                ischeked = false;
                //StaticMethods.AndroidSnackBar("Check");
            }
            else
            {
                IMGTerms.Source = "ic_check_box_outline";
                ischeked = true;
              //  StaticMethods.AndroidSnackBar("UNCheck");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SeveData();//StaticMethods.ShowToast("Submit");
        }

        public void EmptyValues()
        {
            txtCompanyName.Text = txtConPerson.Text = txtEmail.Text = txtPhone.Text = txtPass.Text = txtCurRequi.Text = txtexeperiance.Text = txtSkill.Text = txtJobRoll.Text = txtlocation.Text = txtAddress.Text = string.Empty;
        }

        public void SeveData()
        {
            try
            {
                Erm.COMPANY_NAME = Convert.ToString(txtCompanyName.Text);
                Erm.CONTACT_PERSON = Convert.ToString(txtConPerson.Text);
                Erm.EMAIL =    Convert.ToString(txtEmail.Text);
                Erm.PHONE = Convert.ToString(txtPhone.Text);
                Erm.Password = Convert.ToString(txtPass.Text);
                Erm.CURRENT_REQUIRMENT = Convert.ToString(txtCurRequi.Text);
                Erm.EXPERIENCE = Convert.ToString(txtexeperiance.Text);
                Erm.SKILL = Convert.ToString(txtSkill.Text);
                Erm.JOBROLL = Convert.ToString(txtJobRoll.Text);
                Erm.LOCATION = Convert.ToString(txtlocation.Text);
                Erm.ADDRESS = Convert.ToString(txtAddress.Text);
                api.postEmployerReg(Erm);
                StaticMethods.ShowToast(responseMdl.MESSAGE);
                EmptyValues();
            }
            catch (Exception e)
            {
                StaticMethods.ShowToast(e.Message);
            }
            finally
            {
                Erm = null;
                responseMdl = null;
            }
        }
    }
}
