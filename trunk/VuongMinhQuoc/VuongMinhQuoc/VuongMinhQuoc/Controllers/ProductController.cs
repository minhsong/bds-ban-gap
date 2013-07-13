using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuongMinhQuoc.Models;
using VuongMinhQuoc.Models.DBContext;

namespace VuongMinhQuoc.Controllers
{
    public class ProductController : BaseController
    {
        public bool HasFile(HttpPostedFileBase file)
        {

            return (file != null && file.ContentLength > 0) ? true : false;

        }
       
        // GET: /Product/Details/5
        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            var image = db.ProductImages.Where(pi=>pi.ProductId==id).ToList();
            ViewBag.listImage = image;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }       

        public ActionResult ProductList(int? year, int? type, int? page)
        {
            page = page == null ? 1 : page;
            var result = from s in db.Products
                         where (year == null || s.Year == year)
                         && (type == null || s.TypeId == type)
                         select s;
            return View(result.OrderByDescending(s=>s.CreatedDate).Take(12*(int)page));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}