using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaChoThue.Models.DBContext
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        [MaxLength(150)]
        public string Caption { get; set; }
        [MaxLength(250)]
        public string ImageLink { get; set; }
        [MaxLength(250)]
        public string ThumblLink { get; set; }

        //Reationship object

        public virtual Product Product { get; set; }
    }
}