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
    
    public partial class ItechUsers
    {
        public ItechUsers()
        {
            this.AspNetRoles = new HashSet<AspNetRoles>();
        }
    
        public int id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CardNo { get; set; }
        public string Password { get; set; }
        public Nullable<int> PasswordFormat { get; set; }
        public Nullable<System.DateTime> LastTestKompetencjiDtm { get; set; }
        public Nullable<int> LastTestKompetencjiResult { get; set; }
        public bool Frozen { get; set; }
        public string Desc { get; set; }
        public string AccessProfile { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> LastTestKompetencjiDtmSucces { get; set; }
        public bool ForceTestKompetencji { get; set; }
    
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
    }
}
