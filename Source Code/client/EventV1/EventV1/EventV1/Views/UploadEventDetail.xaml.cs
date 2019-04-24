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
		public UploadEventDetail ()
		{
			InitializeComponent ();
		}

        private async void GoPosterUpload_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UploadEventPoster());
        }
    }
}