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
    
    public partial class ModelsWorkstation
    {
        public int id { get; set; }
        public Nullable<int> idW { get; set; }
        public Nullable<int> idM { get; set; }
        public string index { get; set; }
    
        public virtual Resource ResourceWorkstation { get; set; }
        public virtual Resource ResourceModel { get; set; }
    }
}
