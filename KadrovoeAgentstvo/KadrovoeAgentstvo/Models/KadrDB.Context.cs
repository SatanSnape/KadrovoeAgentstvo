﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KadrovoeAgentstvo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KadrovoeAgentstvoEntities : DbContext
    {
        public KadrovoeAgentstvoEntities()
            : base("name=KadrovoeAgentstvoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<JobDirectory> JobDirectories { get; set; }
    }
}
