using EventV1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendedEvents : ContentPage
	{
		public AttendedEvents ()
		{
			InitializeComponent ();
		}
        async void FeedButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedBack());
        }

        private void ViewAttendedEvnetDetail_Clicked(object sender, EventArgs e)
        {

        }
    }
}