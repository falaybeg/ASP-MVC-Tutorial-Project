using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ExamplesApp.Models;

namespace ExamplesApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        // we defined custom validation for customer's age. 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId ==  MemberShipType.Unknown ||
                customer.MembershipTypeId ==  MemberShipType.PayAsYouGo)

                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership");                
        }
    }
}