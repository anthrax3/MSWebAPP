﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhysioAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MSAppEntities : DbContext
    {
        public MSAppEntities()
            : base("name=MSAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DailyDiary> DailyDiaries { get; set; }
        public virtual DbSet<Degradation> Degradations { get; set; }
        public virtual DbSet<FortnightlyDiary> FortnightlyDiaries { get; set; }
        public virtual DbSet<Injury> Injuries { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Physio> Physios { get; set; }
        public virtual DbSet<Programme> Programmes { get; set; }
        public virtual DbSet<Relaps> Relapses { get; set; }
    }
}
