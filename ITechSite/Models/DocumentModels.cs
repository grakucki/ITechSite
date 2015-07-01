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

    public class FindDokumentModel2
    {
        public string CodeName { get; set; }
        public string Action { get; set; }
    }
    
    public class IndexDokumentModel
    {
//         public  FindDokumentModel Find { get; set; }
         public string CodeName { get; set; }
         public string FindAction { get; set; }
         public int? page { get; set; }

         public PagedList.IPagedList<Dokument> Dokuments { get; set; }
    }

}