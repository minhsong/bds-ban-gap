using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaChoThue.Models;
using NhaChoThue.Helpers;
using NhaChoThue.Models.DBContext;
using NhaChoThue.Models.Enum;

namespace NhaChoThue.Controllers
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
            result = result.OrderByDescending(s=>s.CreatedDate).Skip((pagging - 1) * show.Value).Take(show.Value).ToList();
            return View(result);
        }

        public ActionResult Detail(int Id)
        {
            
            var product = db.Products.Find(Id);
            if (product != null)
            {
                ViewBag.CungGia = (from s in db.Products
                                  where s.IsActive == true
                                  && s.IsDelete == false
                                  && s.IsHired == false
                                  && s.ProductID!=Id
                                  select s).OrderBy(S=>Math.Abs(product.Price-S.Price)).Take(3);
                ViewBag.CungKV = (from s in db.Products
                                   where s.Ward.DistrictID == product.Ward.DistrictID
                                   && s.IsActive == true
                                   && s.IsDelete == false
                                   && s.IsHired == false
                                   && s.ProductID != Id
                                   select s).Take(3).OrderBy(S => S.CreatedDate);
                    product.Views = product.Views + 1;
                    db.Entry(product).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                return View(product);
            }
            return Error(new Exception("Product not existed!"));
        }

        public ActionResult Search(SearchModel search, int? pg, int? show)
        {
            if (show == null)
            {
                show = 15;
            }
            
            if (pg == null)
            {
                pg = 1;
            }

            var SearchResult = (from s in db.Products.AsEnumerable()
                                    where s.IsActive
                                    && s.IsDelete==false
                                    && (search.Dis==null||s.Ward.DistrictID==search.Dis)
                                    &&(search.From == null || s.Price >= search.From)
                                    && (search.To == null || s.Price < search.To)
                                    &&(string.IsNullOrEmpty(search.Title) || NhaChoThue.Helpers.DataConvertHelper.IsContaintIgnoreCulture(s.Title, search.Title)||s.GetID().ToString().Contains(search.Title.Trim()))
                                    && (string.IsNullOrEmpty(search.Duong) || NhaChoThue.Helpers.DataConvertHelper.IsContaintIgnoreCulture(s.DuongTruocNha, search.Duong))
                                select s).ToList().OrderByDescending(s => s.CreatedDate);
            ViewBag.count = SearchResult.Count();
            ViewBag.pg = pg.Value;
            ViewBag.show = show.Value;

            ViewBag.SearchResult = new List<Product>(SearchResult.Skip((pg.Value - 1) * show.Value).Take(show.Value).ToList().OrderByDescending(s => s.CreatedDate));
            ViewBag.Districts = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",search.Dis);

            return View(search);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Consignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Consignment(Consignment cs)
        {
            if (ModelState.IsValid)
            {
                cs.CreatedBy = cs.FullName;
                cs.CreatedDate = DateTime.Now;
                cs.UpdatedBy = cs.FullName;
                cs.UpdatedDate = DateTime.Now;
                db.Consignments.Add(cs);
                db.SaveChanges();
                return RedirectToAction("ConsignmentSuccessed");
            }
            return View(cs);
        }

        public ActionResult ConsignmentSuccessed()
        {
            return View();
        }
    }

}
