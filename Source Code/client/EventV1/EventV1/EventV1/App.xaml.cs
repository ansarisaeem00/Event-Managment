using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using EventV1.Views;
using System;
using EventV1.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EventV1
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
         //  MainPage = new NavigationPage( new OrganizedEvents());
           // MainPage = new NavigationPage( new MainPage());
            // MainPage = new UploadEventResource();
            //MainPage =new NavigationPage( new Register());
           // MainPage = new NavigationPage(new Login()) 
            //SetMainPage();/* 
          /*  {
                BackgroundColor = Color.AliceBlue,
                BarBackgroundColor = Color.CornflowerBlue,
                BarTextColor = Color.White
               
            };*/
        }

      /*  private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new Register());
            }
        */

        protected override void OnStart()
		{
            // Handle when your app starts
            AppCenter.Start("android=19e456e4-0231-4072-a9d1-aca463c73e31;",
                typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
