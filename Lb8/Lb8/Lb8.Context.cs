﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lb8
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class demoEntities : DbContext
    {
        public demoEntities()
            : base("name=demoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<groups> groups { get; set; }
        public virtual DbSet<lectors> lectors { get; set; }
        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<subjects> subjects { get; set; }
        public virtual DbSet<progress> progress { get; set; }
    }
}
