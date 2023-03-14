using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class PickupDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var booking = (Booking)validationContext.ObjectInstance;

            if (booking.PickupDate == null)
                return new ValidationResult("Pickup Date is required.");

            if (booking.PickupDate.Date >= booking.ReturnDate.Date)
                return new ValidationResult("Pickup Date must be at least one day before Return Date.");

            return (booking.PickupDate.Date >= DateTime.Now.Date)
                ? ValidationResult.Success
                : new ValidationResult("Pickup Date can't be before today.");
        }
    }
}