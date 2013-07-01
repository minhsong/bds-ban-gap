using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuongMinhQuoc.Models.DBContext;

namespace VuongMinhQuoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProjectDbContextcs db = new ProjectDbContextcs();
            db.Accounts.ToList();
            return View();
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

    }
}
