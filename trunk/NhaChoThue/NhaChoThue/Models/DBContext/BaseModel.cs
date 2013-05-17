using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaChoThue.Models.DBContext
{
    public class BaseModel
    {
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }
    }
}