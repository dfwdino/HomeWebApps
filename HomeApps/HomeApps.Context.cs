﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeApps
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HomeAppsEntities : DbContext
    {
        public HomeAppsEntities()
            : base("name=HomeAppsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<Mile> Miles { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<CreateModifyLog> CreateModifyLogs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSchema> UserSchemas { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ModelSocialSite> ModelSocialSites { get; set; }
        public virtual DbSet<SocialSite> SocialSites { get; set; }
        public virtual DbSet<ModelImage> ModelImages { get; set; }
    }
}
