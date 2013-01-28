using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models
{
    public class SearchModel
    {
        public string Title { get; set; }
        public double? From { get; set; }
        public double? To { get; set; }
        public int? Dis { get; set; }

        public int? LDO { get; set; }
        public int? PL { get; set; }
        public int? H { get; set; }
        public string Duong { get; set; }
        public int? VT { get; set; }
    }
}