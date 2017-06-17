using App2.Models;
using App2.StaticMethod;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            try
            {
                var content = new MultipartFormDataContent();
                StreamContent scontent = new StreamContent(_mediaFile.GetStream());
                content.Add(scontent, "profile_pic");
                StringContent studentIdContent = new StringContent("sudheer@gmail.com");
                content.Add(studentIdContent,"email");

                var httpClient = new HttpClient();

                var uploadServiceBaseAddress = "http://smtgroup.in/jobpools/wdiapi/index.php/candidate_profilepic";
                //"http://uploadtoserver.azurewebsites.net/api/Files/Upload";
                //"http://localhost:12214/api/Files/Upload";

                var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

                lblCancel.Text = await httpResponseMessage.Content.ReadAsStringAsync();
                StaticMethods.AndroidSnackBar(lblCancel.Text);
            }
            catch (Exception ex)
            {

                StaticMethods.AndroidSnackBar(ex.Message);
            }
            
        }

        //private async void UploadImage()
        //{
        //    //variable
        //    var url = "http://hallpassapi.jamsocialapps.com/api/profile/UpdateProfilePicture/";

        //    try
        //    {
        //        //initialize our media plugin
        //        var media = CrossMedia.Current;

        //        //pick photo
        //        var file = await media.PickPhotoAsync();

        //        // wait until the file is written
        //        while (File.ReadAllBytes(file.Path).Length == 0)
        //        {
        //            System.Threading.Thread.Sleep(1);
        //        }

        //        //read file into upfilebytes array
        //        //var upfilebytes = File.ReadAllBytes(file);

        //        //create new HttpClient and MultipartFormDataContent and add our file, and StudentId
        //        HttpClient client = new HttpClient();
        //        MultipartFormDataContent content = new MultipartFormDataContent();
        //        ByteArrayContent baContent = new ByteArrayContent(upfilebytes);
        //        StringContent studentIdContent = new StringContent("2123");
        //        content.Add(baContent, "File", "filename.ext");
        //        content.Add(studentIdContent, "StudentId");


        //        //upload MultipartFormDataContent content async and store response in response var
        //        var response =
        //            await client.PostAsync(url, content);

        //        //read response result as a string async into json var
        //        var responsestr = response.Content.ReadAsStringAsync().Result;

        //        //debug
        //        Debug.WriteLine(responsestr);

        //    }
        //    catch (Exception e)
        //    {
        //        //debug
        //        Debug.WriteLine("Exception Caught: " + e.ToString());

        //        return;
        //    }
        //}

        private async void Cancel_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}
