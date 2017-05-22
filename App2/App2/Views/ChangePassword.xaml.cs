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
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePass_Clicked(object sender, EventArgs e)
        {

        }
        
        private void NewPassword_Tapped(object sender, EventArgs e)
        {

        }
        
        private void OnOldPass_Tapped(object sender, EventArgs e)
        {

        }

        private void NewPassword_Unfocused(object sender, EventArgs e)
        {

        }
        private void NewPassword_Focused(object sender, EventArgs e)
        {

        }
        private async void OldPassword_Focused(object sender, EventArgs e)
        {
            await Task.Delay(100);
            
            t.Placeholder = string.Empty;
            lblCompanyName.IsVisible = true;

        }
        private void OldPassword_Unfocused(object sender, EventArgs e)
        {
            txtCompanyName.Placeholder = "COMPANY NAME";
            lblCompanyName.IsVisible = false;
        }
    }
}
