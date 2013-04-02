using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BDSBanGap.Models.DBContext
{
    public class Ward:BaseModel
    {
        public int WardID { get; set; }
        [Required]
        [MaxLength(50)]
        public string WardName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int DistrictID { get; set; }

      //realationship object
        public virtual District District { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}