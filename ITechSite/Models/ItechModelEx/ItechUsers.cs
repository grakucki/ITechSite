using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(ItechUsersData))]
    public partial class ItechUsers
    {

    }


    public class ItechUsersData
    {
        [Unique]
        [Required]
        public string UserId { get; set; }
    }

    public class ItechUsersImport
    {
        public HttpPostedFileBase File { get; set; }
        public string FileName { get; set; }
        public int FormAction { get; set; }
        public string MsgOk { get; set; }
        public string MsgError { get; set; }
        public List<string> ErrorItem { get; set; }
        public List<string> StatusList { get; set; }

        // FormAction=0 podaj plik i validacja
        // FormAction=1 plik poprawny czy zapisać
        // FormAction=2 Plik zapisano poprawnie lub nie
    }
}