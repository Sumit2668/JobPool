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
    public partial class Successfully : PopupPage
    {
        public Successfully()
        {
            InitializeComponent();
        }

        public Successfully(string text)
        {
            InitializeComponent();
            lblOK.Text = text;
        }

        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(1);
        }

        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(0); ;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void btnOK_Clicked(object sender, EventArgs e)
        {
            if (lblOK.Text == "Login Successfully")
            {
                Navigation.PushModalAsync(new MainPage());
            }
            await PopupNavigation.PopAsync(true);

        }
    }
}
