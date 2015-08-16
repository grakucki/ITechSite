using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
    [MetadataType(typeof(InformationPlanMetaData))]
    public partial class InformationPlan
    {

    }


    public class InformationPlanMetaData
    {
        public int id { get; set; }
        [DisplayName("Stanowisko/model")]
        public int idR { get; set; }
        [DisplayName("Dokument")]
        [Required]
        public int IdD { get; set; }
        [DisplayName("Sortowanie")]
        public Nullable<int> Order { get; set; }
        [DisplayName("Aktywny")]
        public bool Enabled { get; set; }
    }


    public class InformationPlanModels: InformationPlan
    {
        public string CodeName { get; set; }
        [DisplayName("Kategoria")]
        public int? Kategorie_Id { get; set; }
        [DisplayName("Proces roboczy")]
        public int? WorkProcess { get; set; }
        public string FindAction { get; set; }
        public int? page { get; set; }

        public PagedList.IPagedList<Dokument> Dokuments { get; set; }
    }
}