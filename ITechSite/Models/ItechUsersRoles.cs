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
    
    public partial class ItechUsersRoles
    {
        public int ItechUserId { get; set; }
        public string RoleId { get; set; }
        public Nullable<int> WorkstationId { get; set; }
    
        public virtual AspNetRoles AspNetRoles { get; set; }
        public virtual ItechUsers ItechUsers { get; set; }
    }
}
