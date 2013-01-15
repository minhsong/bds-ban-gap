using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class District:BaseModel
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string Description { get; set; }

        //Realtionship object
        public virtual ICollection<Ward> Wards { get; set; }
    }
}