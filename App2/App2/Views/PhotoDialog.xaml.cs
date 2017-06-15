using App2.Models;
using App2.StaticMethod;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDialog : PopupPage
    {
        private MediaFile _mediaFile;
        public PhotoDialog()
        {
            InitializeComponent();
        }

        private async void TakePhoto_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                StaticMethods.AndroidSnackBar("No Camera");
            }

            _mediaFile = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    //SaveToAlbum = true,
                    Directory = "Sample",
                    Name = "test.jpg",
                });

            if (_mediaFile == null)
                return;
            string LocalPath = _mediaFile.Path;
            MainImage.Source=ImageSource.FromStream(() =>
                {

                    return _mediaFile.GetStream();
                });
            UploadFile();
        }
        private async void SelectPhoto_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                StaticMethods.AndroidSnackBar("Pick Photo Is Not Supported");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
                return;

            MainImage.Source = ImageSource.FromStream(() =>
            {   
                return _mediaFile.GetStream();
            });
            UploadFile();
        }

        private async void UploadFile()
        {
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"",
                $"\"{_mediaFile.Path}\"");
            var httpClient = new HttpClient();

            var uploadServiceBaseAddress = "http://smtgroup.in/jobpools/wdiapi/index.php/candidate_profile";
                //"http://uploadtoserver.azurewebsites.net/api/Files/Upload";
            //"http://localhost:12214/api/Files/Upload";

            var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

          //  lblCancel.Text= await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private async void Cancel_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}
