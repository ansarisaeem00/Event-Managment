using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApi2.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ContentType { get; set; }
        public Byte[] Data { get; set; }
        public String UserId { get; set; }
        public String EventId { get; set; }
       
    }
}