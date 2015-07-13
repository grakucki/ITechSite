using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(NewsMetaData))]
    public partial class News
    {

    }


    public class NewsMetaData
    {
        [DisplayName("Wiadomość")]
        public string News1 { get; set; }
        [DisplayName("Ważna do")]
        public Nullable<System.DateTime> ValidEnd { get; set; }
        [DisplayName("Utworzona przez")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}