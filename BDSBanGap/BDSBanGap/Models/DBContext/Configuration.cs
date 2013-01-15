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
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}