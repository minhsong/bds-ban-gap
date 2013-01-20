using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models;
using BDSBanGap.Models.Enum;

namespace BDSBanGap.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var result = from s in db.Products
                         where s.IsActive == true
                         && s.IsDelete == false
                         && s.IsSold == false
                         select s;
            return View(result);
        }

        public ActionResult Detail(int Id)
        {
            
            var product = db.Products.Find(Id);
            if (product != null)
            {
                ViewBag.CungGia = (from s in db.Products
                                  where Math.Abs(s.Price - product.Price) < 0.5
                                  && s.IsActive == true
                                  && s.IsDelete == false
                                  && s.IsSold == false
                                  select s).Take(3).OrderBy(S=>S.CreatedDate);
                    product.Views = product.Views + 1;
                    db.Entry(product).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                return View(product);
            }
            return Error(new Exception("Product not existed!"));
        }

        public ActionResult Search(SearchModel search)
        {
            ViewBag.SearchResult = (from s in db.Products
                         where (string.IsNullOrEmpty(search.Title) || s.Title.ToLower().Contains(search.Title))
                         && (search.PriceFrom == null || s.Price >= search.PriceFrom)
                         && (search.PriceTo == null || s.Price < search.PriceTo)
                         && (search.LoaiDiaOc ==null|| search.LoaiDiaOc==s.LoaiDiaOc)
                         && (search.Huong ==null||search.Huong==s.Huong)
                         && (search.TinhTrangPhapLy==null||search.TinhTrangPhapLy ==s.TinhTrangPhapLy)
                         && (search.ViTriDiaOc==null||search.ViTriDiaOc==s.ViTriDiaOc)
                         select s).ToList();
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",search.Huong);
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",search.LoaiDiaOc);
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",search.TinhTrangPhapLy);
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",search.ViTriDiaOc);
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",search.District);
            return View(search);
        }

        public ActionResult About()
        {
            return View();
        }
    }

}
