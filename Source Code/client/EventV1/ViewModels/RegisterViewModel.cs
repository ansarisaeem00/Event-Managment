using EventV1.Helpers;
using EventV1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventV1.ViewModels
{
    public class RegisterViewModel
    {
        //private Register register = new Register();
        private ApiServices _apiServices = new ApiServices();
        public string Message { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        


        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);
                    if (isSuccess.IsSuccessStatusCode)
                    {
                        await NavHelper.CurrentPage.DisplayAlert("Success", "Logged In", "OK");
                        await NavHelper.PushAsync(new MainPage());
                        Settings.Username = Email;
                        Settings.Password = Password;
                    }
                    else if(isSuccess.StatusCode.Equals(400) )
                    {
                        await NavHelper.CurrentPage.DisplayAlert("Failed To Register", "Invalid Email Or Password", "OK");
                        await NavHelper.PushAsync(new Login());
                    }
                    else if (isSuccess.StatusCode.Equals(500))
                    {
                        await NavHelper.CurrentPage.DisplayAlert("Failed To Register", "Email Already Used", "OK");
                        await NavHelper.PushAsync(new Login());
                    }
                    else
                    {
                        await NavHelper.CurrentPage.DisplayAlert("Failed To Register", "Invalid Email Or Password", "OK");
                        await NavHelper.PushAsync(new Register());
                    }
                        
                    
                });
            }
        }
    }
}
