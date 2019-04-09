using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Models
{
    public class Search
    {
        [Required]
        [MaxLength(140)]
        public string from { get; set; }

        [Required]
        [MaxLength(140)]
        public string to { get; set; }

        [Required]
        [MaxLength(140)]
        public string fromtime { get; set; }

      
        [MaxLength(140)]
        public string totime { get; set; }

      
        [MaxLength(140)]
        public string airline_choice { get; set; }

      
        [MaxLength(140)]
        public string price_range { get; set; }


        [Required]
        public int people_count { get; set; }





    }
}