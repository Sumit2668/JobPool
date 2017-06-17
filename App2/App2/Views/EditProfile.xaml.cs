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
    public partial class EditProfile : ContentPage
    {
        public EditProfile()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.MainPage.Width > 0 && Application.Current.MainPage.Height > 0)
            {
                var calcScreenWidth = Application.Current.MainPage.Width;
                var calcScreenHieght = Application.Current.MainPage.Height;
                MainGrid.HeightRequest = calcScreenHieght / 3;
                CircleImg.WidthRequest = calcScreenWidth / 4;
                CircleImg.HeightRequest = calcScreenWidth / 4;
                lblEditProfile.WidthRequest = calcScreenWidth;
                
            }
        }

        private async void PhotoPopup_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new PhotoDialog());
        }
    }
}
