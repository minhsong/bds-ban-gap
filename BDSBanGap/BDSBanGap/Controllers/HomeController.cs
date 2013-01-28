using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models;
using BDSBanGap.Models.Enum;
using BDSBanGap.Helpers;
using BDSBanGap.Models.DBContext;

namespace BDSBanGap.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int? pg, int? show)
        {
            show = show == null ? 15 : show.Value;
            int pagging = pg == null ? 1 : pg.Value;

            var result = (from s in db.Products
                          where s.IsActive == true
                          && s.IsDelete == false
                          select s).ToList();
            ViewBag.count = result.Count();
            ViewBag.pg = pagging;
            ViewBag.show = show;
            result = result.Skip((pagging - 1) * show.Value).Take(show.Value).ToList();
            return View(result.OrderByDescending(s => s.CreatedDate));
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
                                  && s.ProductID!=Id
                                  select s).Take(3).OrderBy(S=>S.CreatedDate);
                    product.Views = product.Views + 1;
                    db.Entry(product).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                return View(product);
            }
            return Error(new Exception("Product not existed!"));
        }

        public ActionResult Search(SearchModel search, int? pg, int? show)
        {
            show = show == null ? 15 : show.Value;
            int pagging = pg == null ? 1 : pg.Value;

            var SearchResult = (from s in db.Products.AsEnumerable()
                                    where s.IsActive
                                    && s.IsDelete==false
                                    && (search.Dis==null||s.Ward.DistrictID==search.Dis)
                                    &&(search.From == null || s.Price >= search.From)
                                    && (search.To == null || s.Price < search.To)
                                    && (search.LDO == null || search.LDO == s.LoaiDiaOc)
                                    && (search.H == null || search.H == s.Huong)
                                    && (search.PL == null || search.PL == s.TinhTrangPhapLy)
                                    && (search.VT == null || search.VT == s.ViTriDiaOc)
                                    &&(string.IsNullOrEmpty(search.Title) || BDSBanGap.Helpers.DataConvertHelper.IsContaintIgnoreCulture(s.Title, search.Title))
                                    && (string.IsNullOrEmpty(search.Duong) || BDSBanGap.Helpers.DataConvertHelper.IsContaintIgnoreCulture(s.DuongTruocNha, search.Duong))
                                    select s).ToList();
            ViewBag.count = SearchResult.Count();
            ViewBag.pg = pagging;
            ViewBag.show = show;

            ViewBag.SearchResult = new List<Product>(SearchResult.Skip((pagging - 1) * show.Value).Take(show.Value).ToList().OrderByDescending(s => s.CreatedDate));
            ViewBag.Huongs = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",search.H);
            ViewBag.LoaiDiaOcs = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",search.LDO);
            ViewBag.Phaplys = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",search.PL);
            ViewBag.VitriDiaOcs = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",search.VT);
            ViewBag.Districts = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",search.Dis);
            return View(search);
        }

        public ActionResult About()
        {
            return View();
        }
    }

}
