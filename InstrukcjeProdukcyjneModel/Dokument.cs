//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InstrukcjeProdukcyjneModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dokument
    {
        public Dokument()
        {
            this.InformationPlan = new HashSet<InformationPlan>();
        }
    
        public int Id { get; set; }
        public string FileName { get; set; }
        public string CodeName { get; set; }
        public System.DateTime LastWriteTime { get; set; }
        public bool Enabled { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public System.DateTime ValidDtmOn { get; set; }
        public Nullable<System.DateTime> ValidDtmOff { get; set; }
        public Nullable<int> WorkProcess_Id { get; set; }
        public string Keywords { get; set; }
    
        public virtual ICollection<InformationPlan> InformationPlan { get; set; }
    }
}
