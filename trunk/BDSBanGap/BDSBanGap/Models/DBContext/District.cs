using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BDSBanGap.Models.DBContext
{
    public class District:BaseModel
    {
        public int DistrictID { get; set; }
        [Required]
        [MaxLength(50)]
        public string DistrictName { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        //Realtionship object
        public virtual ICollection<Ward> Wards { get; set; }
    }
}