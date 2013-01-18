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
        public IEnumerable<int> District { get; set; }

        public int? LoaiDiaOc { get; set; }
        public int? TinhTrangPhapLy { get; set; }
        public int? Huong { get; set; }
        public string DuongTruocNha { get; set; }
        public int? ViTriDiaOc { get; set; }

        public int? SoLau { get; set; }
        public int? SoPhongNgu { get; set; }
        public int? SoPhongTam { get; set; }
        public int? SoPhongKhac { get; set; }

        //Thong Tin tien ich
        public bool? DayDuTienNghi { get; set; }
        public bool? ChoDauXeHoi { get; set; }
        public bool? SanVuon { get; set; }
        public bool? HoBoi { get; set; }
        public bool? TienKinhDoanh { get; set; }
        public bool? TienDeO { get; set; }
        public bool? TienLamVanPhong { get; set; }
        public bool? TienSanXuat { get; set; }
        public bool? ChoSinhVienThue { get; set; }

    }
}