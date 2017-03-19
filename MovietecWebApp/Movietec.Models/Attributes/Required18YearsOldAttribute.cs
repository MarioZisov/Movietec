using Movietec.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movietec.Models.Attributes
{
    public class Required18YearsOldAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required to go on this membership.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (age < 18)
                return new ValidationResult("Customer should be at least 18 years old to go on this membership.");
            else
                return ValidationResult.Success;
        }
    }
}
