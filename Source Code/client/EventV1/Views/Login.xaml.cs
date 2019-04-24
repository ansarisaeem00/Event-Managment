using EventV1;
using EventV1.Helpers;
using EventV1.Services;
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
	public partial class Login : ContentPage
	{
        private ApiServices apiServices = new ApiServices();

        public Login ()
		{
			InitializeComponent ();
		}

		async private void Signup_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Register());
		}
        

        async private void SignInButton_Clicked(object sender, EventArgs e)
		{
           
          /*  if (!string.IsNullOrEmpty(ApiServices.token))
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {

                await DisplayAlert("Error", "User Not Found Please Try Again", "Ok");
            }*/

        }

        /*public async void Decline()
        {
            await DisplayAlert("Error", "Login Failed", "Try Again");
            await Navigation.PushAsync(new Login());
        }

        public async void Accept()
        {
            await DisplayAlert("Success", "Successfully Logged In", "OK");
            await Navigation.PushAsync(new MainPage());
        }*/

        private async void Skip_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register2());
        }
        
    }
}