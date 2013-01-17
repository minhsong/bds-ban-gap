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
                return View(product);
            }
            return Error(new Exception("Product not existed!"));
        }

        public ActionResult About()
        {
            return View();
        }
    }

}
