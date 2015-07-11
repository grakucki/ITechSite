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
    public class Test
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int score { get; set; }
        [DataMember]
        public int stateId { get; set; }
        [DataMember]
        public int userId { get; set; }
        [DataMember]
        public string accessionNumber { get; set; }
        [XmlArray("questions")]
        [XmlArrayItem("question")]
        public TestQuestions[] questions { get; set; }
        [XmlArray("userAnswers")]
        [XmlArrayItem("answer")]
        public UserAnswer[] userAnswers { get; set; }
    }
}