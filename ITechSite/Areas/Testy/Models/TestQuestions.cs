using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITechSite.Areas.Testy.Models
{
    [Serializable]
    public class TestQuestions
    {
        public int id { get; set; }
        public string content { get; set; }
    }
}