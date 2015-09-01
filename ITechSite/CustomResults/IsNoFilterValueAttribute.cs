using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.CustomResults
{
    public class IsNoFilterValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
                //return new ValidationResult("Wybierz poprawną wartość.");

            if (value.GetType() == typeof(int))
            {
                int i = (int)value;
                if (i<=0)
                    return new ValidationResult("Wybierz poprawną wartość.");

                return ValidationResult.Success;
            }

            if (value.GetType() == typeof(string))
            {
                string i = (string)value;
                if (i=="*")
                    return new ValidationResult("Wybierz poprawną wartość.");

                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}