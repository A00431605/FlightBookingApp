namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("flight")]
    public partial class flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int flight_id { get; set; }

        public int? airline_id { get; set; }

        [StringLength(50)]
        public string flight_no { get; set; }

        [Display(Name = "Departure From ")]
        [StringLength(50)]
        public string flight_from { get; set; }

        [StringLength(50)]
        [Display(Name = "Arrival To")]
        public string flight_to { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Departure Date")]
        public DateTime? operating_date_from { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Arrival Date")]
        public DateTime? operating_date_to { get; set; }

        [StringLength(50)]
        public string flight_timing_from { get; set; }

        [StringLength(50)]
        public string flight_timing_to { get; set; }

        public int? total_seats { get; set; }

        public int? seats_booked { get; set; }

        public int? seats_blocked { get; set; }
        public List<flight> flightList { get; set; }

        public int? cost { get; set; }
        public string flight_name { get; set; }
    }
}
