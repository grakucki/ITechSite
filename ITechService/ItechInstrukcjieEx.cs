using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ITechService;

namespace ITechInstrukcjeModel
{
    public class ItechInstrukcjieEx
    {
        //[DataContract]
        //public partial class NewsMetaData
        //{
        //    [IgnoreDataMember]
        //    public int id { get; set; }
        //    [DataMember]
        //    public string News1 { get; set; }
        //    [DataMember]
        //    public Nullable<System.DateTime> ValidEnd { get; set; }
        //    [IgnoreDataMember]
        //    public Resource Resource { get; set; }
        //}

        //[MetadataType(typeof(NewsMetaData))]

        public partial class News
        {
            public static News Clone(News o)
            {
                return new News().From(o);
            }
        }
    }
}