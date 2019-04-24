using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadEventDetail : ContentPage
	{
        private MediaFile _mediaFile;
        public UploadEventDetail ()
		{
			InitializeComponent ();
		}

        private async void GoPosterUpload_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UploadEventPoster());
        }



        private async void PickPhoto_Clicked(object sender, EventArgs e)

        {
/*
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
*/
        }


        private async void TakePhoto_Clicked(object sender, EventArgs e)

        {
/*
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
*/
        }




    }
}