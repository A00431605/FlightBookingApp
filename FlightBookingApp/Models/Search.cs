using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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

        [Required]
        [MaxLength(140)]
        public string totime { get; set; }

        [Required]
        [MaxLength(140)]
        public string airline_choice { get; set; }

        [Required]
        [MaxLength(140)]
        public string price_range { get; set; }


        [Required]
        [MaxLength(140)]
        public string people_count { get; set; }




    }
}