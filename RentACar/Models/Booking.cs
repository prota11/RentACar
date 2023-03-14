using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [ForeignKey("Customer")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Pickup Location")]
        public string PickupLocation { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Return Location")]
        public string ReturnLocation { get; set; }
        [Required]
        [PickupDateValidation]
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }
        [Required]
        [ReturnDateValidation]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [Required]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public int Price { get; set; }

    }
}