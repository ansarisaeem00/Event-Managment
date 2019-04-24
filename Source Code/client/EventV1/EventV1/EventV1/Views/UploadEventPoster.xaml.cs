using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadEventPoster : ContentPage
	{
        private MediaFile _mediaFile;
        public UploadEventPoster ()
		{
			InitializeComponent ();
		}

        private async void PickPhoto_Clicked(object sender, EventArgs e)

        {

            await CrossMedia.Current.Initialize();
            
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {

                await DisplayAlert("No PickPhoto", ":( No PickPhoto available.", "OK");
                 return;

            }
            
            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            
            if (_mediaFile == null)
                return;
            
            LocalPathLabel.Text = _mediaFile.Path;
            
            FileImage.Source = ImageSource.FromStream(() =>

            {

                return _mediaFile.GetStream();

            });

        }



        private async void TakePhoto_Clicked(object sender, EventArgs e)

        {

            await CrossMedia.Current.Initialize();
            
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;

            }
            
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "myImage.jpg"

            });
            
            if (_mediaFile == null)
                return;
            
            LocalPathLabel.Text = _mediaFile.Path;
            
            FileImage.Source = ImageSource.FromStream(() =>
            {

                return _mediaFile.GetStream();

            });

        }



        private async void UploadFile_Clicked(object sender, EventArgs e)

        {

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(_mediaFile.GetStream()),"\"file\"",$"\"{_mediaFile.Path}\"");
            
            var httpClient = new HttpClient();
            
            var uploadServiceBaseAddress = "https://backendapi.conveyor.cloud/api/Files/Upload";

            //"http://localhost:12214/api/Files/Upload";
            
            var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
            
            RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();

        }


    }
}