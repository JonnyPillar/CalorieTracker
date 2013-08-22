using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CalorieTracker.Validators
{
    public class DateOfBirthValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime enteredValue;
                if(DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out enteredValue))
                {
                    if (enteredValue.CompareTo(DateTime.Now) < 0) //Earlier Than
                    {
                        //Need to add in a max age
                        return ValidationResult.Success;
                    }
                }
                else return new ValidationResult("Not Valid Format: DD/MM/YYYY");
            }
            return new ValidationResult("Not A Valid Date");
        }
    }
}