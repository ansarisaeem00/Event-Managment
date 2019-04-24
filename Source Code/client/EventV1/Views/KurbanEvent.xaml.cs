using EventV1.Models;
using EventV1.Services;
using EventV1.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KurbanEvent : ContentPage
	{
        ApiServices apiServices = new ApiServices();
        public List<EventUpload> Content { get; set; }
        public async Task<List<EventUpload>> GetEventsAsync(string SearchText=null)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUploads");
            Content = JsonConvert.DeserializeObject<List<EventUpload>>(json);
            if(string.IsNullOrWhiteSpace(SearchText))
                return Content;

            //string.IsNullOrWhiteSpace(Content.Where(c => c.EventName).Contain(SearchText));
            //if()
            
            return Content.Where(c => c.EventVenue.ToLower().Contains(SearchText.ToLower())).ToList();
            //return Content.Where(c => c.EventName.StartsWith(SearchText)).ToList();
        }


        public KurbanEvent ()
		{
			InitializeComponent ();
            //EventViewModel view = new EventViewModel();
            //view.GetEventCommand;
            //OnAppearing();
            
            //listView.ItemsSource = Content;


        }

        protected override async void OnAppearing()
        {
           // Content = await GetEventsAsync();
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("https://backendapi.conveyor.cloud/api/EventUploads");
            Content = JsonConvert.DeserializeObject<List<EventUpload>>(json);
            
           // Content.OrderByDescending(item => item.time);
            listView.ItemsSource = Content.OrderByDescending(item => item.date);
            Progress.IsRunning = false;
            Progress.IsVisible = false;
            //return Content;

        }

        private  void ListView_Refreshing(object sender, EventArgs e)
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