using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(ResourceTypeMetaData))]
    public partial class ResourceType
    {
        
    }

    class ResourceTypeMetaData
    {
         [DisplayName("Typ")]
        public string Type { get; set; }
    }
}