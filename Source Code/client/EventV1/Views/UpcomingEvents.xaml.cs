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
	public partial class UpcomingEvents : ContentPage
	{
		public UpcomingEvents ()
		{
			InitializeComponent ();
		}

        private void ViewUpcomingEvnetDetail_Clicked(object sender, EventArgs e)
        {

        }
        async void ReportButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Report());
        }

    }
}