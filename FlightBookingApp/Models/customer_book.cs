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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string customer_emailaddress { get; set; }

        [StringLength(256)]
        public string customer_postalcode { get; set; }

        [StringLength(256)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string customer_password { get; set; }

        [StringLength(256)]
        [NotMapped]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("customer_password",ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public String LoginErrorMessage { get; set; }
    }
}
