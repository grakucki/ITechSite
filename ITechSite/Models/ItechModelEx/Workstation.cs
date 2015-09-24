using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(WorkstationMetaData))]
    public partial class Workstation
    {
        
    }

    class WorkstationMetaData
    {
        [DisplayName("IP Komputera")]
        [MaxLength(15)]
        public string AllowIp { get; set; }
    }
}