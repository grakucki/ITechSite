//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITechSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resource
    {
        public Resource()
        {
            this.InformationPlan = new HashSet<InformationPlan>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public System.DateTime LastWriteTime { get; set; }
        public string No { get; set; }
        public string WorkProcess { get; set; }
        public bool Enabled { get; set; }
    
        public virtual ICollection<InformationPlan> InformationPlan { get; set; }
        public virtual Model Model1 { get; set; }
        public virtual Workstation Workstation1 { get; set; }
    }
}
