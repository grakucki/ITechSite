//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITechInstrukcjeModel
{
    using System;
    using System.Collections.Generic;
using System.Runtime.Serialization;
    
    public partial class InformationPlan
    {
        public int id { get; set; }
        public int idR { get; set; }
        public int IdD { get; set; }
        public Nullable<int> Order { get; set; }
        public bool Enabled { get; set; }
    
        public virtual Dokument Dokument { get; set; }
        [IgnoreDataMember]
        public virtual Resource Resource { get; set; }
    }
}
