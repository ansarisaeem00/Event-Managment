using EventV1.Models;
using EventV1.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrganizedEvents : ContentPage
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

            //string.IsNullOrWhiteSpace(Content.Where(c => c.EventName).Contain(SearchText));
            //if()

            return Content.Where(c => c.EventVenue.ToLower().Contains(SearchText.ToLower())).ToList();
            //return Content.Where(c => c.EventName.StartsWith(SearchText)).ToList();
        }
        public OrganizedEvents ()
		{
			InitializeComponent ();
		}
        async void ReportButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Report());
        }

        private async void ViewOrganizedEvnetDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAllPost());
        }

        private void Predict_Clicked(object sender, EventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            EventUpload eventobj = new EventUpload();
            // Content = await GetEventsAsync();
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUploads");
            Content = JsonConvert.DeserializeObject<List<EventUpload>>(json);

            // Content.OrderByDescending(item => item.time);
            //Content.OrderByDescending(item => item.date);
            
            listView.ItemsSource = Content.Where(c => c.UserId.Equals(eventobj.UserId));
            Progress.IsRunning = false;
            Progress.IsVisible = false;
            //return Content;

        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {

            OnAppearing();
            listView.EndRefresh();
        }

        private async void Searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = await GetEventsAsync(e.NewTextValue);
        }
    }
}