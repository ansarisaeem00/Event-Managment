using EventV1.Helpers;
using EventV1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventV1.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventV1.Models;
using System.Net.Http;
using Newtonsoft.Json;
using EventV1.Services;

namespace EventV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        ApiServices apiServices = new ApiServices();
        public List<EventUpload> Content { get; set; }
        public async Task<List<EventUpload>> GetEventsAsync(string SearchText = null)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUploads");
            Content = JsonConvert.DeserializeObject<List<EventUpload>>(json);
            if (string.IsNullOrWhiteSpace(SearchText))
                return Content;
            return Content.Where(c => c.EventName.ToLower().Contains(SearchText.ToLower())).ToList();
        }

        public Home ()
		{
            
			InitializeComponent ();
            
			HomeScreen.BackgroundColor = Color.AliceBlue;

            Username.Text = Settings.Username;
            
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private async void ViewDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewEventDetail());
        }


        /* Fetching the data as list */
        protected override async void OnAppearing()
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUploads");
            Content = JsonConvert.DeserializeObject<List<EventUpload>>(json);
            listView.ItemsSource = Content.OrderByDescending(item => item.date);
            //return Content;
            Progress.IsRunning = false;
            Progress.IsVisible = false;
        }

        /* Pull to refresh */
        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            OnAppearing();
            listView.EndRefresh();
        }

        /*Searching*/
        private async void Searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = await GetEventsAsync(e.NewTextValue);
        }

    }
}