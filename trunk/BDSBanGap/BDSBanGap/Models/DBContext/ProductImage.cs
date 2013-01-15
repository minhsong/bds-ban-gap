using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models.DBContext
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public string Caption { get; set; }
        public string ImageLink { get; set; }
        public string ThumblLink { get; set; }

        //Reationship object

        public virtual Product Product { get; set; }
    }
}