﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITechEntities : DbContext
    {
        public ITechEntities()
            : base("name=ITechEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dokument> Dokument { get; set; }
        public virtual DbSet<InformationPlan> InformationPlan { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Workstation> Workstation { get; set; }
        public virtual DbSet<News> News { get; set; }
    }
}
