using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class Booked: BaseModel
    {
        public int id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Description { get; set; }
        public byte Type { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool IsSolved { get; set; }
        public string Districts { get; set; }
    }
}