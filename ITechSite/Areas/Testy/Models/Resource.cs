//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITechSite.Areas.Testy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resource
    {
        public Resource()
        {
            this.AllowedCategories = new HashSet<AllowedCategories>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public System.DateTime LastWriteTime { get; set; }
        public string No { get; set; }
        public string WorkProcess { get; set; }
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    
        public virtual ICollection<AllowedCategories> AllowedCategories { get; set; }
    }
}
