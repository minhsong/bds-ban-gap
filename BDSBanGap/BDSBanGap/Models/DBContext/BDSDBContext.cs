﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BDSBanGap.Models.DBContext
{
    public class BDSDBContext:DbContext
    {
        public DbSet<Configuration> BDSConfigurations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<BDSUser> Users { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<PriorityProduct> Priorities { get; set; }
        public DbSet<Booked> Bookeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(s => s.Images).WithRequired(s => s.Product).HasForeignKey(s => s.ProductID);
            base.OnModelCreating(modelBuilder);
        }
    }
}