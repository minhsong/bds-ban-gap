using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BDSBanGap.Models.DBContext
{
    public class Configuration:BaseModel
    {
        [Key]
        [MaxLength(50)]
        public string ConfigKey { get; set; }
        [MaxLength(100)]
        public string Value { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}