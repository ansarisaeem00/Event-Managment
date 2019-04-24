using EventV1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent ();
        }

      
        private async void GotoEditProfile_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfile());
        }

        private async void OrganizedEvents_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrganizedEvents());

        }

        private async void Terms_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Terms());

        }


        private async void AttendedEvents_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AttendedEvents());


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void UpcomingEvents_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpcomingEvents());
        }

        

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}