using Rg.Plugins.Popup.Pages;
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
    public partial class FilterLoction : PopupPage
    {
        public FilterLoction()
        {
            InitializeComponent();
        }
       
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.MainPage.Width > 0 && Application.Current.MainPage.Height > 0)
            {
                var calcScreenWidth = Application.Current.MainPage.Width;
                var calcScreenHieght = Application.Current.MainPage.Height;
                FSort.HeightRequest = FDepartment.HeightRequest = FSalary.HeightRequest = FEducation.HeightRequest = FIndustry.HeightRequest = FLocation.HeightRequest = FRole.HeightRequest = calcScreenWidth / 10 - 15;
                Row1.Height = Row2.Height = Row3.Height = Row4.Height = Row5.Height = Row6.Height = Row7.Height = calcScreenHieght / 7-11;
                Column1.Width = calcScreenWidth / 3;
            }
        }
        private async void Sort_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterSort());
        }

        private async void Salary_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterSalary());
        }

        private async void Location_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterLoction());
        }

        private async void Role_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterRole());
        }

        private async void Education_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterEducation());
        }

        private async void Industry_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterIndustry());
        }

        private async void Department_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new FilterDepartment());
        }

        private void Apply_Tapped(object sender, EventArgs e)
        {

        }
    }
}
