using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models
{
    public class ProductListView: BaseModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Caption { get; set; }
    }
}