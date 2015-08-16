using ITechSite.CustomResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(ResourceMetaData))]
    public partial class Resource
    {

    }


    public class ResourceMetaData
    {
        [Unique]
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string Name { get; set; }

        [DisplayName("Typ")]
        public int Type { get; set; }

        [DisplayName("Zmodyfikowany")]
        public System.DateTime LastWriteTime { get; set; }

        [DisplayName("Numer")]
        public string No { get; set; }

        [DisplayName("Proces roboczy")]
        [IsNoFilterValue]
        public string WorkProcess { get; set; }

        [DisplayName("Fabryka")]
        [IsNoFilterValue]
        public string Factory { get; set; }


        [DisplayName("Aktywny")]
        public bool Enabled { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Słowa kluczowe")]
        public string Keywords { get; set; }
    }
}