﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NimapInfotechProject.SqlContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbNimapInfotechTaksEntities : DbContext
    {
        public DbNimapInfotechTaksEntities()
            : base("name=DbNimapInfotechTaksEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MCategory> MCategories { get; set; }
        public virtual DbSet<MProduct> MProducts { get; set; }
    
        public virtual ObjectResult<SpProduct_Result> SpProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpProduct_Result>("SpProduct");
        }
    }
}