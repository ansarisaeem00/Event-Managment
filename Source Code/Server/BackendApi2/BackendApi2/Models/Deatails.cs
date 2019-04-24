using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApi2.Models
{
    public class Deatails
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
        public string FacultyCordinator { get; set; }
        public string StudentCordinator { get; set; }
        public string Sponsor { get; set; }
        public string TechSupport { get; set; }
        public string Guest { get; set; }
        public string ResoursePerson { get; set; }
        public string Outcome { get; set; }
        public string Budget { get; set; }
        public string EnrollId { get; set; }
    }
}