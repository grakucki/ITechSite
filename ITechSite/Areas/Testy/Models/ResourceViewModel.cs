using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITechSite.Areas.Testy.Models
{
    public class ResourceViewModel
    {
        [Display(Name = "Nazwa stanowiska")]
        [Required(ErrorMessage = "Nazwa stanowiska jest polem obowiązkowym")]
        public string name { get; set; }

        public List<Kategorie> categories { get; set; }
    }
}