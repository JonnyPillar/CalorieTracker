﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Utils.NewFolder1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Metric> Metrics { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodNutrient> FoodNutrients { get; set; }
        public virtual DbSet<Nutrient> Nutrients { get; set; }
    }
}
