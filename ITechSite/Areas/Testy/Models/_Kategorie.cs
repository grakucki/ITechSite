using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITechSite.Areas.Testy.Models
{
    public class KategorieMetaData
    {
        [Display(Name = "Nazwa kategorii")]
        [Required(ErrorMessage = "Nazwa kategorii jest polem obowiązkowym!")]
        [UniqueName]
        public string name { get; set; }
    }

    [MetadataType(typeof(KategorieMetaData))]
    public partial class Kategorie
    {
        
    }

    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = new TestyEntities();
            var currentCategory = validationContext.ObjectInstance as Kategorie;
            var duplicated = db.Kategorie.Where(c => c.name == (string)value && c.id != currentCategory.id).SingleOrDefault();

            if(duplicated == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Kategoria o podanej nazwie już istnieje!");
        }
    }
}