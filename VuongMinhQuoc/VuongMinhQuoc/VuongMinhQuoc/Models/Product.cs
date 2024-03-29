﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models
{
    public class Product:BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HostName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int TypeId { get; set; }
        public virtual ICollection<ProductImages> Imanges { get; set; }
        public virtual ProductType Type { get; set; }

    }
}