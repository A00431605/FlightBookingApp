namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("passenger")]
    public partial class passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int passenger_id { get; set; }

        [StringLength(256)]
        public string passport_number { get; set; }

        [StringLength(256)]
        public string passenger_address { get; set; }

        [StringLength(256)]
        public string passenger_postalCode { get; set; }

        [StringLength(256)]
        public string passenger_Country { get; set; }

        [StringLength(256)]
        public string passenger_phoneNumber { get; set; }

        [StringLength(256)]
        public string passenger_emailAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? passenger_DOB { get; set; }

        [StringLength(50)]
        public string passenger_gender { get; set; }
    }
}
