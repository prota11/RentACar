using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentACar.Models;

namespace RentACar.Models
{
    public class CustomerAlreadyExists : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public CustomerAlreadyExists()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.Email == null)
                return new ValidationResult("Email is required.");

            var customers = _context.Customers.ToList();
            foreach(var cust in customers)
            {
                if(customer.Email == cust.Email && customer.Id != cust.Id)
                {
                    return new ValidationResult("Customer with that email already exists");
                }
            }
            return ValidationResult.Success;
        }
    }
}