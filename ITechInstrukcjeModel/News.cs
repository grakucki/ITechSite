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
    
    public partial class News
    {
        public int id { get; set; }
        public string News1 { get; set; }
        public Nullable<System.DateTime> ValidEnd { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }

        [IgnoreDataMember]
        public virtual Resource Resource { get; set; }
    }
}
