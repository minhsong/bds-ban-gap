using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models
{
    public class ProductType:BaseModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}