using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class Ward:BaseModel
    {
        public int WardID { get; set; }
        public string WardName { get; set; }
        public string Description { get; set; }
    }
}