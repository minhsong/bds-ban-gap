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

        public ActionResult About()
        {
            return View();
        }
    }

}
