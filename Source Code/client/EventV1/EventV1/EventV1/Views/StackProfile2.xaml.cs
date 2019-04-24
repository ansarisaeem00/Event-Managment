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
	public partial class StackProfile2 : ContentPage
	{
		public StackProfile2()
		{
			InitializeComponent();
			GoButton.BackgroundColor = Color.CornflowerBlue;
			GoButton.TextColor = Color.White;
			CircleShowsNo.BackgroundColor = Color.CornflowerBlue;
			OrganizedCirlceText.TextColor = Color.White;
		}

		async void EditProfileButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EditProfile());
		}
		private void GoButton_Clicked(object sender, EventArgs e)
		{

		}
		async void ViewAllPost(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ViewAllPost());
		}

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        
    }
}