namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("airline")]
    public partial class airline
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int airline_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string airline_name { get; set; }
    }
}
