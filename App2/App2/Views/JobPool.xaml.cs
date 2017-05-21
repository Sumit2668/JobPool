using App2.Models;
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
    public partial class JobPool : ContentPage
    {
        public JobPool()
        {
            InitializeComponent();
            LoadData();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Device.BeginInvokeOnMainThread(() =>
			{
				if (Device.OS == TargetPlatform.iOS)
				{ 
				if (Application.Current.MainPage.Height > 0)
					{
						var calcScreenHieght = Application.Current.MainPage.Height;
						MainGrid.HeightRequest = calcScreenHieght / 2 + 150;

					}
				}
				else
				{
					if (Application.Current.MainPage.Height > 0)
					{
						var calcScreenHieght = Application.Current.MainPage.Height;
						MainGrid.HeightRequest = calcScreenHieght / 2 + 45;

					}
				}
			});
		
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("Success");
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

        public void LoadData()
        {
            List<JobPoolMdl> jobmdl = new List<JobPoolMdl>();
            if (jobmdl.Count == 0)
            {
                jobmdl = JobPoolMdl.PreJobPoolList();
              
            }
            MainListView.ItemsSource = jobmdl;
        }

        private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
