using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(TestSettingsMetaData))]
    public partial class TestSettings
    {
        
    }

    class TestSettingsMetaData
    {
        public int id { get; set; }
        [DisplayName("Wykonuj test co (dni)")]
        public int Test_PeriodDay { get; set; }
        [DisplayName("Blokuj maszynę gdy test niezdany")]
        public int Test_BlokOnValid { get; set; }
        [DisplayName("Wywołuj test automatycznie")]
        public bool Test_Run { get; set; }
    }
}