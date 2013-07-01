using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models.DBContext
{
    public class ProjectDbContextcs:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasMany(s => s.Imanges).WithRequired(s => s.Product).HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<Account>().HasRequired(s => s.Role).WithMany(s => s.Users).HasForeignKey(s => s.RoleID);
        }

    }
}