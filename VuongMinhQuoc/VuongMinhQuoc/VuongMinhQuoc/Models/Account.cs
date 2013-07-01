using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VuongMinhQuoc.Models.DBContext
{
    public class Account:BaseModel
    {
        [Key]
        [MaxLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }

        //relationship object
        public virtual Role Role { get; set; }
    }
}