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
    public partial class TestPage1 : ContentPage
    {
        public TestPage1()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Candidate());   
        }

        private void BorderEntry_Focused(object sender, FocusEventArgs e)
        {
            //txtEntry.IsEnabled = false;
            //Navigation.PushModalAsync(new Candidate());
            //txtEntry.IsEnabled = true;
        }
    }
}
