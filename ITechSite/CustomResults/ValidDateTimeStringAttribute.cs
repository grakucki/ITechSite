using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.CustomResults
{
   
    public class ValidDateTimeStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dtout;
            if (DateTime.TryParse(value.ToString(), out dtout))
            {
                return true;
            }
            return false;
        }
    }
}