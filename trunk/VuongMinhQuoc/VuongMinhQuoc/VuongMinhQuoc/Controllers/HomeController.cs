using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuongMinhQuoc.Models.DBContext;

namespace VuongMinhQuoc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            
            return View(db.Products.Take(4));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Prices()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

    }
}
