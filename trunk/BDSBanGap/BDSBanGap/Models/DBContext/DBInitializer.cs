using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BDSBanGap.Models.DBContext
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            //user and role
            #region User and role init data
            Role role = new Role()
            {
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                RoleName = "Administrator",
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
            };

            context.Entry(role).State = System.Data.EntityState.Added;
            context.SaveChanges();

            BDSUser user = new BDSUser()
            {
                Address = "14 Hoa Su, p7 , Phu Nhuan",
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                Email = "truongminhsong@gmail.com",
                FullName = "Minh Song",
                Password = "12345",
                Phone = "0938505866",
                RoleID = 1,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now,
                Username = "Admin"
            };

            context.Entry(user).State = System.Data.EntityState.Added;
            context.SaveChanges();
            #endregion

            //District
            #region District init

            District dt = new District()
            {
                DistrictName = "Phu Nhuan",
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                UpdatedBy = "System",
                UpdatedDate = DateTime.Now
            };
            context.Entry(dt).State = System.Data.EntityState.Added;
            context.SaveChanges();

            #endregion

            //Wards
            #region Wards init

            Ward w = new Ward()
            {
                DistrictID = 1,
                WardName = "7",
            };
            context.Entry(w).State = System.Data.EntityState.Added;
            Ward w1 = new Ward()
            {
                DistrictID = 1,
                WardName = "2",
            };
            context.Entry(w1).State = System.Data.EntityState.Added;
            context.SaveChanges();
            #endregion
            //product
            #region Product init data

            Product pd = new Product()
            {
                ChoDauXeHoi = false,
                ChoSinhVienThue = false,
                CNDai = 16.5,
                CNNgangSau = 5,
                CNNgangTruoc = 4.5,
                DayDuTienNghi = true,
                Description = "nha day du tien nghi, mat tien thoang mat, an ninh",
                DuongTruocNha = "Nguy Van Troi",
                HoBoi = false,
                Huong = 1,
                IsActive = true,
                IsSold = false,
                KVDai = 16,
                KVNgangSau = 5,
                KVNgangTruoc = 4.5,
                LoaiDiaOc = 1,
                Price = 12.5,
                SanVuon = false,
                SoLau = 4,
                SoPhongKhac = 2,
                SoPhongKhach = 2,
                SoPhongNgu = 9,
                SoPhongTam = 10,
                TienDeO = true,
                TienKinhDoanh = true,
                TienLamVanPhong = true,
                TienSanXuat = true,
                TinhTrangPhapLy = 1,
                Titile = "Ban nha nguyen can mat tien duong Nguyen Van Troi",
                ViTriDiaOc = "Mat tien",
                XDDai = 16,
                XDNgangSau = 5,
                XDNgangTruoc = 4.5,
                WardID = 1,
            };

            context.Entry(pd).State = System.Data.EntityState.Added;
            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}