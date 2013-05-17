using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NhaChoThue.Models.DBContext
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
        public DbSet<Consignment> Consignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(s => s.Images).WithRequired(s => s.Product).HasForeignKey(s => s.ProductID);
            modelBuilder.Entity<Consignment>().HasKey(s => s.Id).HasOptional(s => s.Product).WithMany(s => s.Consignments).HasForeignKey(s => s.ProductId).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}