using App2.Models;
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
    public partial class JobPoolList : ContentPage
    {
        public JobPoolList()
        {
            InitializeComponent();
            LoadData();
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
