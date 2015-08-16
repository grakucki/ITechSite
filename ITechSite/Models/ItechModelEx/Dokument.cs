using ITechSite.CustomResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{

    [MetadataType(typeof(DokumentMetaData))]
    public partial class Dokument
    {

        public string Size2
        {
            get
            {
                if (!this.Size.HasValue)
                    return "-";
                var units = new[] { "B", "KB", "MB", "GB", "TB" };
                var index = 0;
                double size = this.Size.Value;
                while (size > 1024 && index + 1 < units.Length)
                {
                    size /= 1024;
                    index++;
                }
                return string.Format("{0:N2} {1}", size, units[index]);
            }
        }
    }

    public class DokumentMetaData
    {
        [DisplayName("Nazwa pliku")]
        [Required]
        public string FileName { get; set; }

        [DisplayName("Nazwa kodowa")]
        public string CodeName { get; set; }

        [DisplayName("Zmodyfikowany")]
        public System.DateTime LastWriteTime { get; set; }

        [DisplayName("Aktywny")]
        public bool Enabled { get; set; }

        [DisplayName("Typ pliku")]
        public string FileType { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Aktywny od")]
        [DataType(DataType.Date)]
        public System.DateTime ValidDtmOn { get; set; }

        [DisplayName("Aktywny do")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ValidDtmOff { get; set; }

        [DisplayName("Proces roboczy id")]
        [IsNoFilterValue]
        public Nullable<int> WorkProcess_Id { get; set; }

        [DisplayName("Słowa kluczowe")]
        public string Keywords { get; set; }

        [DisplayName("Rozmiar")]
        public Nullable<long> Size { get; set; }

        [DisplayName("Lokalna nazwa pliku")]
        public string LocalFileName { get; set; }

        [DisplayName("Proces roboczy")]
        public virtual WorkProcess WorkProcess { get; set; }

        [DisplayName("Kategoria")]
        public virtual Kategorie Kategorie { get; set; }

        [DisplayName("Kategoria")]
        [IsNoFilterValue]
        public Nullable<int> Kategoria_Id { get; set; }


        //public virtual ICollection<FileContent> FileContent { get; set; }
        //public virtual ICollection<InformationPlan> InformationPlan { get; set; }
    }
}