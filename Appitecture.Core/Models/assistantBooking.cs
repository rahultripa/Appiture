using System;
using System.Collections.Generic;
using System.Linq;


namespace Appitecture.Core.Models
{
   
    public class assistantBooking
    {
        public int Id { get; set; }
        public int assistantId { get; set; }
        public int UserId { get; set; }
        public String name { get; set; }
        public DateTime  date  { get; set; }
   
        public DateTime fromDateTime { get; set; }
        public DateTime ToDate { get; set; }
        public String Comments { get; set; }


    }
}