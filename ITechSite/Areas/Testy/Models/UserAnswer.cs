using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ITechSite.Areas.Testy.Models
{
    [Serializable]
    public class UserAnswer
    {
        [DataMember]
        public int answerId { get; set; }
        [DataMember]
        public int questionId { get; set; }
        [DataMember]
        public bool isCorrect { get; set; }
    }
}