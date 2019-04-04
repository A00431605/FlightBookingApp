namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("airport")]
    public partial class airport
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int airport_id { get; set; }

        [StringLength(50)]
        public string airport_name { get; set; }

        [StringLength(3)]
        public string airport_short_code { get; set; }

        [StringLength(50)]
        public string airport_country { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string city { get; set; }
    }
}
