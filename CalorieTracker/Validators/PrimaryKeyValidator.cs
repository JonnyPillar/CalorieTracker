using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Validators
{
    public class PrimaryKeyValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("No Primary Key");
            }
        }
    }
}