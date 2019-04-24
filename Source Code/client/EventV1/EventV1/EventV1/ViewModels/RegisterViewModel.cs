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
        private Register register = new Register();
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
                   // Register.IsSuccess = isSuccess;
                    Settings.Username = Email;
                    Settings.Password = Password;
                    if (isSuccess)
                    {
                        // register.Accept();
                    }
                    else
                        Message = "error";
                       // register.Decline();
                });
            }
        }
    }
}
