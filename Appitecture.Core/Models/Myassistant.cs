using System;
using System.Collections.Generic;
using System.Linq;

namespace Appitecture.Core.Models
{
   
    public class Myassistant
    {
        public int assistantId { get; set; }
   public string     name { get; set; }
    public Double    wagesPerHour { get; set; }
   
   public DateTime availability { get; set; }
        public string languages { get; set; }
        public int  localplaceknowledge { get; set; }
        public string profession { get; set; }
        public string vehicles { get; set; }
        public string description { get; set; }
    public string  ratting { get; set; }
        public string  reviews { get; set; }
        public string imageURL { get; set; }
        public string  contactInfo { get; set; }

        public Double lat { get; set; }

        public Double lng { get; set; }
    }
}