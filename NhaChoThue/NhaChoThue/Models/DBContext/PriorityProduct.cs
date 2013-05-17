using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaChoThue.Models.DBContext
{
    public class PriorityProduct:BaseModel
    {
        public int PriorityProductID { get; set; }
        public int ProductID { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        //Relationship object

        public virtual Product Product { get; set; }
    }
}