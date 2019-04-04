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
        public string Status { get; set; }
    }
}