using App2.StaticMethod;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCandidate : PopupPage
    {
        public SelectCandidate()
        {
            InitializeComponent();
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

        private async void Candidate_Tapped(object sender, System.EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
            await Navigation.PushModalAsync(new CandidateReg());
        }
        private async void Employer_Tapped(object sender, System.EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
            await Navigation.PushModalAsync(new EmployeeRegister());
        }
    }
}
