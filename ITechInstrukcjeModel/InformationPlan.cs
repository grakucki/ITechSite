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
    
    public partial class InformationPlan
    {
        public int id { get; set; }
        public int idR { get; set; }
        public int IdD { get; set; }
        public Nullable<int> Order { get; set; }
        public bool Enabled { get; set; }
        public Nullable<int> IdM { get; set; }
        public string OwnerId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    
        public virtual Dokument Dokument { get; set; }
        [System.Runtime.Serialization.IgnoreDataMember]
	public virtual Resource ResourceWorkstation { get; set; }
        [System.Runtime.Serialization.IgnoreDataMember]
	public virtual Resource ResourceModel { get; set; }
    }
}


