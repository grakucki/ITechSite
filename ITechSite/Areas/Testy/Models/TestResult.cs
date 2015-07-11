using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ITechSite.Areas.Testy.Models
{
    [KnownType(typeof(DataContractSerializer))]
    [DataContract]
    public class TestResult
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Nullable<int> score { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string accessionNumber { get; set; }
    }
}