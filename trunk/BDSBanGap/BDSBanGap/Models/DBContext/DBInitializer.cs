using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BDSBanGap.Models.DBContext
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            base.Seed(context);
        }
    }
}