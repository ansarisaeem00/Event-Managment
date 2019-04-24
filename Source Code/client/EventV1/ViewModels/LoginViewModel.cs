using EventV1.Helpers;
using EventV1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventV1.ViewModels
{
    public class LoginViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        //private Login login = new Login();
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    Settings.AccessToken = accesstoken;

                    if (!string.IsNullOrEmpty(accesstoken))
                    {
                        
                        await NavHelper.CurrentPage.DisplayAlert("Success", "Logged In", "OK");
                        await NavHelper.PushAsync(new MainPage());
                    }
                    
                    else
                    {
                        await NavHelper.CurrentPage.DisplayAlert("Error", "Loggin Failed", "OK");

                        await NavHelper.PushAsync(new Login());
                    }
                });
            }
        }
        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = "";
                    Settings.Username = "";
                    Settings.Password = "";
                });
            }
        }
    }
}
