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
    public partial class Candidate : ContentPage
    {
        Boolean ischeked = false;
        public Candidate()
        {
            InitializeComponent();
            if (IMGTerms.Source != null)
            {
                ischeked = true;
            }
        }
        private void Email_OnFocused(object sender, FocusEventArgs e)
        {
            // Debug.WriteLine("Email Focused");
        }

        private void Email_OnUnfocused(object sender, FocusEventArgs e)
        {
            // Debug.WriteLine("Email Unfocused");
        }

        private async Task txtlocation_Focused(object sender, FocusEventArgs e)
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

        private async Task txtexeperiance_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtexeperiance.Placeholder = string.Empty;
            lblExpEriance.IsVisible = true;
        }

        private void txtexeperiance_Unfocused(object sender, FocusEventArgs e)
        {
            txtexeperiance.Placeholder = "EXPERIANCE";
            lblExpEriance.IsVisible = false;
        }

        private async Task txtSkill_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtSkill.Placeholder = string.Empty;
            lblSkill.IsVisible = true;
        }

        private void txtSkill_Unfocused(object sender, FocusEventArgs e)
        {
            txtSkill.Placeholder = "SKILL & CERTIFICATION";
            lblSkill.IsVisible = false;
        }

        private async Task txtStrengths_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtStrengths.Placeholder = string.Empty;
            lblStrengths.IsVisible = true;
        }

        private void txtStrengths_Unfocused(object sender, FocusEventArgs e)
        {
            txtStrengths.Placeholder = "STRENGTHS";
            lblStrengths.IsVisible = false;
        }

        private async Task txtExeSalary_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtExeSalary.Placeholder = string.Empty;
            lblExeSalary.IsVisible = true;
        }

        private void txtExeSalary_Unfocused(object sender, FocusEventArgs e)
        {
            txtExeSalary.Placeholder = "EXPECTED SALARY";
            lblExeSalary.IsVisible = false;
        }

        private async Task txtCAddress_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtCAddress.Placeholder = string.Empty;
            lblCAddress.IsVisible = true;
        }

        private void txtCAddress_Unfocused(object sender, FocusEventArgs e)
        {
            txtCAddress.Placeholder = "COMPELETE ADDRESS";
            lblCAddress.IsVisible = false;
        }

        private async Task txtPreLocation_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtPreLocation.Placeholder = string.Empty;
            lblPreLocation.IsVisible = true;
        }

        private void txtPreLocation_Unfocused(object sender, FocusEventArgs e)
        {
            txtPreLocation.Placeholder = "PREFERED LOCATION";
            lblPreLocation.IsVisible = false;
        }

        private async Task txtObjectives_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtObjectives.Placeholder = string.Empty;
            lblObjectives.IsVisible = true;
        }

        private void txtObjectives_Unfocused(object sender, FocusEventArgs e)
        {
            txtObjectives.Placeholder = "OBJECTIVES";
            lblObjectives.IsVisible = false;
        }

        private async Task txtBDescription_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtBDescription.Placeholder = string.Empty;
            lblBDescription.IsVisible = true;
        }

        private void txtBDescription_Unfocused(object sender, FocusEventArgs e)
        {
            txtBDescription.Placeholder = "BRIEF DESCRIPTION";
            lblBDescription.IsVisible = false;
        }

        private void Terms_Tapped(object sender, EventArgs e)
        {
            if (ischeked)
            {
                IMGTerms.Source = "ic_check_box";
                ischeked = false;
                StaticMethods.AndroidSnackBar("Check");
            }
            else
            {
                IMGTerms.Source = "ic_check_box_outline";
                ischeked = true;
                StaticMethods.AndroidSnackBar("UNCheck");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("submit");
        }
    }
}
