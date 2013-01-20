using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDSBanGap.Models
{
    public class SearchModel
    {
        public string Title { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public int? District { get; set; }

        public int? LoaiDiaOc { get; set; }
        public int? TinhTrangPhapLy { get; set; }
        public int? Huong { get; set; }
        public string DuongTruocNha { get; set; }
        public int? ViTriDiaOc { get; set; }
    }
}