using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NhaChoThue.Models.DBContext
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            //user and role
            #region User and role init data
            Role role = new Role()
            {
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                RoleName = "Administrator",
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
            };

            context.Entry(role).State = System.Data.EntityState.Added;
            context.SaveChanges();

            BDSUser user = new BDSUser()
            {
                Address = "14 Hoa Su, p7 , Phu Nhuan",
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                Email = "truongminhsong@gmail.com",
                FullName = "Minh Song",
                Password = "12345",
                Phone = "0938505866",
                RoleID = 1,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
                Username = "Admin"
            };

            context.Entry(user).State = System.Data.EntityState.Added;
            context.SaveChanges();
            #endregion

            //District
            #region District init

            District dt = new District()
            {
                DistrictName = "Phu Nhuan",
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now
            };
            context.Entry(dt).State = System.Data.EntityState.Added;
            context.SaveChanges();

            #endregion

            //Wards
            #region Wards init

            Ward w = new Ward()
            {
                DistrictID = 1,
                WardName = "7",
                
            };
            context.Entry(w).State = System.Data.EntityState.Added;
            Ward w1 = new Ward()
            {
                DistrictID = 1,
                WardName = "2",
            };
            context.Entry(w1).State = System.Data.EntityState.Added;
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}