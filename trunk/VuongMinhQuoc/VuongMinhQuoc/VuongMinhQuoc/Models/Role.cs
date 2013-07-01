using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models.DBContext
{
    public class Role:BaseModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Descriptoin { get; set; }

        public virtual ICollection<Account> Users { get; set; }
    }
}