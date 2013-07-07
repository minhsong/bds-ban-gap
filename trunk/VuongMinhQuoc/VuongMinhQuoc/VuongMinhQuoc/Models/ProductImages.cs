using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models
{
    public class ProductImages:BaseModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ThumbLink { get; set; }
        public string Caption { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}