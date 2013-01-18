using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models;

namespace BDSBanGap.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Detail(int Id)
        {
            var product = db.Products.Find(Id);
            if (product != null)
            {
                return View(product);
            }
            return Error(new Exception("Product not existed!"));
        }

        public ActionResult Search(SearchModel search)
        {
            var result = from s in db.Products
                         where (string.IsNullOrEmpty(search.Title) || s.Title.ToLower().Contains(search.Title))
                         && (search.PriceFrom == null || s.Price >= search.PriceFrom)
                         && (search.PriceTo == null || s.Price < search.PriceTo)
                         select s;
            return View("Index",result);
        }

        public ActionResult About()
        {
            return View();
        }
    }

}
