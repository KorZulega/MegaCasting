﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MegaCasting.DBLib
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MegaCastingEntities : DbContext
    {
        public MegaCastingEntities()
            : base("name=MegaCastingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
    }
}
