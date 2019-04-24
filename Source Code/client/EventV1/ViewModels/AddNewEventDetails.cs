using EventV1.Helpers;
using EventV1.Models;
using EventV1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventV1.ViewModels
{
    public class AddNewEventDetails
    {
        ApiServices apiServices = new ApiServices();
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EventName { get; set; }
        public string EventVenue { get; set; }
        public string CollegeName { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var eventUpload = new EventUpload
                    {
                        EventName = EventName,
                        EventVenue = EventVenue,
                        CollegeName = CollegeName,
                        date = date,
                        time = time,
                        Category = Category,
                        Description = Description

                    };
                   string res = await apiServices.PostEventAsync(eventUpload, Settings.AccessToken);
                   Settings.Eid = res;
                    
                });
            }
        }
    }
}
