﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BDSBanGap.Models.DBContext
{
    public class Product:BaseModel
    {
        public int ProductID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsSold { get; set; }
        public int Views { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? SoldPrice { get; set; }
        //Dientich
        public double DienTichSuDung { get; set; }

        //So do khuong vien
        public double? KVNgangTruoc { get; set; }
        public double? KVNgangSau { get; set; }
        public double? KVDai { get; set; }

        //so do DT cong nhan
        public double? CNNgangTruoc { get; set; }
        public double? CNNgangSau { get; set; }
        public double? CNDai { get; set; }

        public int LoaiDiaOc { get; set; }
        public int TinhTrangPhapLy { get; set; }
        public int Huong { get; set; }
        [MaxLength(50)]
        public string DuongTruocNha { get; set; }
        public int ViTriDiaOc { get; set; }

        public int? SoLau { get; set; }
        public int? SoPhongNgu { get; set; }
        public int? SoPhongTam { get; set; }
        public int? SoPhongKhac { get; set; }

        //Thong Tin tien ich
        public bool DayDuTienNghi { get; set; }
        public bool ChoDauXeHoi { get; set; }
        public bool SanVuon { get; set; }
        public bool HoBoi { get; set; }
        public bool TienKinhDoanh { get; set; }
        public bool TienDeO { get; set; }
        public bool TienLamVanPhong { get; set; }
        public bool TienSanXuat { get; set; }
        public bool ChoSinhVienThue { get; set; }

        public int ContactId { get; set; }
        public int WardID { get; set; }

        //realtionship object

        public virtual Ward Ward { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<PriorityProduct> Priorities { get; set; }

        //methods
        #region Methods

        public bool IsCurrentPriority()
        {
            var lp = from s in Priorities
                    where s.StarDate <= DateTime.Now
                    && s.EndDate >= DateTime.Now
                    && s.IsDelete==false
                    && s.IsActive ==true
                    select s;
            if (lp.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public PriorityProduct CurrentPriority()
        {
            var result = (from s in Priorities
                          where s.StarDate <= DateTime.Now
                          && s.EndDate >= DateTime.Now
                          select s).FirstOrDefault();
            return result;
        }
        #endregion

    }
}