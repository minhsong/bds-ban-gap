using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuongMinhQuoc.Models
{
    public class Post:BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Conclusion { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }

    }
}