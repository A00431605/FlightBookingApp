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
        public int customer_id { get; set; }

        [StringLength(256)]
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public string customer_name { get; set; }

     
        [StringLength(256)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        public string customer_emailaddress { get; set; }

        [StringLength(256, ErrorMessage = "Minimum 5 characters", MinimumLength = 5)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")] 
        public string customer_password { get; set; }


        [StringLength(256)]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("customer_password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
        
        [NotMapped]
        public String LoginErrorMessage { get; set; }

    }
}
