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
    
    public partial class ModelsWorkstation
    {
        public int id { get; set; }
        public Nullable<int> idW { get; set; }
        public Nullable<int> idM { get; set; }
        public string index { get; set; }

        [System.Runtime.Serialization.IgnoreDataMember]
        public virtual Resource Workstation { get; set; }
        [System.Runtime.Serialization.IgnoreDataMember]
        public virtual Resource Models { get; set; }
    }
}
