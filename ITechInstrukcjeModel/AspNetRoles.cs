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
    
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            this.ItechUsers = new HashSet<ItechUsers>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        [System.Runtime.Serialization.IgnoreDataMember]
	
	public virtual ICollection<ItechUsers> ItechUsers { get; set; }
    }
}


