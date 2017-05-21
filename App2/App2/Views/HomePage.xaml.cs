using App2.StaticMethod;
using Rg.Plugins.Popup.Services;
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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Device.BeginInvokeOnMainThread(() => { if (Application.Current.MainPage.Width >0)
            {
                var calcScreenWidth = Application.Current.MainPage.Width;
				btnFB.WidthRequest= btnGoogle.WidthRequest=btnLog.WidthRequest=btnReg.WidthRequest = calcScreenWidth / 2 ;
            }});
            
		}

        private async void txtSkill_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtSkill.Placeholder = string.Empty;
            lblSkill.IsVisible = true;
        }

        private void txtSkill_Unfocused(object sender, FocusEventArgs e)
        {
            txtSkill.Placeholder = "SKILL,JOB,ROLL";
            lblSkill.IsVisible = false;
        }

        private async void txtlocation_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(100);
            txtlocation.Placeholder = string.Empty;
            lblLocation.IsVisible = true;
        }

        private void txtlocation_Unfocused(object sender, FocusEventArgs e)
        {
            txtlocation.Placeholder = "CITY";
            lblLocation.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("Submited");
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new SelectCandidate());
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        private void Google_Clicked(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("Comming Soon");
        }

        private void FB_Clicked(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("Comming Soon");
        }
    }
}
