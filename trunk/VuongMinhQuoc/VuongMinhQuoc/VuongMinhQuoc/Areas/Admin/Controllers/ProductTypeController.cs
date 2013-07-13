using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuongMinhQuoc.Models;
using VuongMinhQuoc.Models.DBContext;

namespace VuongMinhQuoc.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        private ProjectDbContextcs db = new ProjectDbContextcs();

        //
        // GET: /Admin/ProductType/

        public ActionResult Index()
        {
            return View(db.Types.ToList());
        }

        //
        // GET: /Admin/ProductType/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductType producttype = db.Types.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        //
        // GET: /Admin/ProductType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ProductType/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProductType producttype, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(producttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producttype);
        }

        //
        // GET: /Admin/ProductType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductType producttype = db.Types.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        //
        // POST: /Admin/ProductType/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producttype);
        }        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}