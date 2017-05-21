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
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.MainPage.Width > 0 && Application.Current.MainPage.Height > 0)
            {
               var calcScreenWidth =Application.Current.MainPage.Width;
                var calcScreenHieght= Application.Current.MainPage.Height;
                MainGrid.HeightRequest = calcScreenHieght / 2 - 70;
                CircleImg.WidthRequest = calcScreenWidth / 3;
                CircleImg.HeightRequest= calcScreenWidth / 3;
                lblCandidate.WidthRequest = calcScreenWidth / 2;
                lblDownload.WidthRequest = calcScreenWidth / 2;

            }
        }
    }
}
