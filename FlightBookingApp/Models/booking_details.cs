namespace FlightBookingApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class booking_details
    {
        [Key]
        [Column(Order = 0)]
        public int booking_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customer_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int flight_id { get; set; }

        [StringLength(256)]
        public string payment { get; set; }

        public int? qty { get; set; }

        [StringLength(256)]
        public string status { get; set; }
        [Required(ErrorMessage = "Please enter valid credit card number")]
        [CreditCard(ErrorMessage = "Invalid Credit Card Number")]
        public string cc { get; set; }

        [Required(ErrorMessage = "Name of credit card is required.")]
        public string NameOnCC { get; set; }

        [Required(ErrorMessage = "Please choose appropriate card type.")]
        public string cardType { get; set; }

        [Required(ErrorMessage = "Please select valid expiry date")]
        public string expDate { get; set; }

        [Required(ErrorMessage = "Please enter passenger details first")]
        public string passenger_id { get; set; }
    }
}
