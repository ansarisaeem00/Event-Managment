using System;
using System.Collections.Generic;
using System.Text;

namespace EventV1.Models
{
    public class EventUpload
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EventName { get; set; }
        public string EventVenue { get; set; }
        public string CollegeName { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
