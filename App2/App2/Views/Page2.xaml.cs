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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            StaticMethods.AndroidSnackBar("Success");
        }
    }
}
