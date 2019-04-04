namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer_book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_id { get; set; }

        [StringLength(256)]
        public string country { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(256)]
        public string customer_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_Date { get; set; }

        [StringLength(256)]
        public string customer_address { get; set; }

        [StringLength(256)]
        public string customer_phonenumber { get; set; }

        [StringLength(256)]
        public string customer_emailaddress { get; set; }

        [StringLength(256)]
        public string customer_postalcode { get; set; }

        [StringLength(256)]
        public string customer_password { get; set; }
    }
}
