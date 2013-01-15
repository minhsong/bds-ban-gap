using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class Contact:BaseModel
    {
        public int ContactID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}