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

        [StringLength(50)]
        public string flight_from { get; set; }

        [StringLength(50)]
        public string flight_to { get; set; }

        [Column(TypeName = "date")]
        public DateTime? operating_date_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime? operating_date_to { get; set; }

        [StringLength(50)]
        public string flight_timing_from { get; set; }

        [StringLength(50)]
        public string flight_timing_to { get; set; }

        public int? eco_total_seats { get; set; }

        public int? eco_seats_booked { get; set; }

        public int? eco_seats_blocked { get; set; }

        public int? firstclass_total_seats { get; set; }

        public int? firstclass_seats_booked { get; set; }

        public int? firstclass_seats_blocked { get; set; }

        public int? eco_cost { get; set; }

        public int? firstclass_cost { get; set; }
    }
}
