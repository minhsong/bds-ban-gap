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
            //int categoryID = db.Categories.Where(s => s.Type == "post").FirstOrDefault().Id;
            //var result = from s in db.Posts where s.CategoryId == categoryID select s;
            //return View(result);
            return View();
        }

        public ActionResult ServicesKienTruc()
        {
            return View();
        }

        public ActionResult ServicesXayDung()
        {
            return View();
        }

        public ActionResult Prices()
        {
            return View();
        }      

        public ActionResult Admin()
        {
            return View();
        }

    }
}
