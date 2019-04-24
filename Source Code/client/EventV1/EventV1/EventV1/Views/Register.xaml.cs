using EventV1.ViewModels;
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
    public partial class Register : ContentPage
    {
        public RegisterViewModel registerViewModel = new RegisterViewModel();
        //public static bool IsSuccess{get;set;}
        public Register()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        	private async void SignInButton_Clicked(object sender, EventArgs e)
            {
            await Navigation.PushAsync(new MainPage());
               /* if(pass.Text==confirmpass.Text)
                {
                    await DisplayAlert("Success", "You Registered Successfully", "Ok");
                    //await Navigation.PushAsync(new MainPage());
                }

                else
                {
                    await DisplayAlert("Error", "Passwords Don't match", "Ok");
                    //await Navigation.PushAsync(new MainPage());
                }*/

             }

	
     /*   async public void Accept()
        {
            await DisplayAlert("Success", "You Registered Successfully", "Ok");
            await Navigation.PushAsync(new MainPage());

        }

        async public void Decline()
        {
            await DisplayAlert("Error", "Passwords Don't match", "Ok");
        }*/
    }
}