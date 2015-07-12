using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(WorkProcessMetaData))]
    public partial class WorkProcess
    {
        
    }

    class WorkProcessMetaData
    {
         [DisplayName("Proces roboczy")]
        public string Name { get; set; }
    }
}