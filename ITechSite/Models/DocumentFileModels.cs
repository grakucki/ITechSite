using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
//    public class DocumentFile : Dokument

    public class FileData
    {
        public string Name { get; set; }
        public Stream File { get; set; }
    }

    public partial class Dokument
    {

        //public Dokument doc = new Dokument();
        public Stream File { get; set; }

        public Dokument GetDokument()
        {
            Dokument b = this;
            return b;
        }
    }
}