using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VuongMinhQuoc.Models.DBContext
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

            Account user = new Account()
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
            base.Seed(context);
        }
    }
}