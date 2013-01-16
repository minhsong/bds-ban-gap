using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDSBanGap.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(db.Products.ToList());
        }

        public ActionResult DetailProduct(int productId)
        {
            var product = db.Products.Find(productId);
            
            if (product != null)
            {
                var ward = db.Wards.Find(product.WardID);
                var district = db.Districts.Find(ward.DistrictID);
                ViewBag.product = product;
                ViewBag.ward = ward;
                ViewBag.district = district;
                return View();
            }
            return Error("Product not existed!");
        }

        public ActionResult About()
        {
            return View();
        }
    }

}
