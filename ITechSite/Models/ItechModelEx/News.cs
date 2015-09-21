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
//        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ValidEnd { get; set; }
        [DisplayName("Utworzona")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}