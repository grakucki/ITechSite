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
    
    public partial class ItechUsersDokumentRead
    {
        public int DokId { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> LastReadAt { get; set; }
        public int DokVersion { get; set; }
        public Nullable<System.DateTime> FirstReadAt { get; set; }
        public int ReadCount { get; set; }
    
        [System.Runtime.Serialization.IgnoreDataMember]
	public virtual Dokument Dokument { get; set; }
        [System.Runtime.Serialization.IgnoreDataMember]
	public virtual ItechUsers ItechUsers { get; set; }
    }
}


