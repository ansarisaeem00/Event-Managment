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
	public partial class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
			InitializeComponent ();

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5,0.5,AbsoluteLayout.AutoSize , AbsoluteLayout.AutoSize) );

            FullSplashScreen.Children.Add(SplashImage);
            this.BackgroundColor = Color.CornflowerBlue;
            this.Content = FullSplashScreen;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(0.9, 1500 ,Easing.Linear);

            await SplashImage.ScaleTo(150, 1200, Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new KurbanEvent());

        }
    }
}