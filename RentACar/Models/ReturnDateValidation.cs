using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class ReturnDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var booking = (Booking)validationContext.ObjectInstance;

            if (booking.ReturnDate == null)
                return new ValidationResult("Return Date is required.");

            if (booking.PickupDate.Date >= booking.ReturnDate.Date)
                return new ValidationResult("Return Date must be at least one day after Pickup Date.");

            return (booking.ReturnDate.Date > DateTime.Now.Date)
                ? ValidationResult.Success
                : new ValidationResult("Return Date can't be before tomorrow.");
        }
    }
}