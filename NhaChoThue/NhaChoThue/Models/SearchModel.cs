using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaChoThue.Models
{
    public class SearchModel
    {
        public string Title { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public int? Dis { get; set; }
        public string Duong { get; set; }
    }
}