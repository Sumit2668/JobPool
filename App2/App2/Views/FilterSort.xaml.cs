using Rg.Plugins.Popup.Pages;
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
    public partial class FilterSort : ContentPage
    {
        public FilterSort()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.MainPage.Width > 0 && Application.Current.MainPage.Height > 0)
            {
                var calcScreenWidth = Application.Current.MainPage.Width;
                var calcScreenHieght = Application.Current.MainPage.Height;
               FSort.HeightRequest= FDepartment.HeightRequest =FSalary.HeightRequest=FEducation.HeightRequest=FIndustry.HeightRequest=FLocation.HeightRequest=FRole.HeightRequest= calcScreenWidth/ 8;
                //Row0.Height = Row1.Height = Row2.Height = Row3.Height = Row4.Height = Row5.Height = Row6.Height =
                    Column1.Width= calcScreenWidth / 3;
               
                //MainGrid.HeightRequest = calcScreenHieght / 2 - 70;
                //CircleImg.WidthRequest = calcScreenWidth / 3;
                //CircleImg.HeightRequest = calcScreenWidth / 3;
                //lblCandidate.WidthRequest = calcScreenWidth / 2;
                //lblDownload.WidthRequest = calcScreenWidth / 2;

            }
        }
    }   
}
