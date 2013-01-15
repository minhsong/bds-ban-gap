using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class BaseModel
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}