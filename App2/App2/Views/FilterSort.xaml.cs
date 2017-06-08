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
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.MainPage.Width > 0 && Application.Current.MainPage.Height > 0)
            {
                var calcScreenWidth = Application.Current.MainPage.Width;
                var calcScreenHieght = Application.Current.MainPage.Height;
                //FSort.HeightRequest= FSort.WidthRequest=FDepartment.HeightRequest =FDepartment.WidthRequest=FSalary.HeightRequest=FSalary.WidthRequest=FEducation.HeightRequest=FEducation.WidthRequest=FIndustry.HeightRequest=FIndustry.WidthRequest=FLocation.HeightRequest=FLocation.WidthRequest=FRole.HeightRequest= calcScreenWidth / 4;
                Row0.Height = Row1.Height = Row2.Height = Row3.Height = Row4.Height = Row5.Height = Row6.Height = Column1.Width= calcScreenWidth / 4-23;
                
                //MainGrid.HeightRequest = calcScreenHieght / 2 - 70;
                //CircleImg.WidthRequest = calcScreenWidth / 3;
                //CircleImg.HeightRequest = calcScreenWidth / 3;
                //lblCandidate.WidthRequest = calcScreenWidth / 2;
                //lblDownload.WidthRequest = calcScreenWidth / 2;

            }
        }
    }
}
