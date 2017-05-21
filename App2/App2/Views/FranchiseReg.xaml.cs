using App2.StaticMethod;
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
    public partial class FranchiseReg : ContentPage
    {
        public FranchiseReg()
        {
            InitializeComponent();
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            StaticMethods.ShowToast("Submit");
        }
    }
}
