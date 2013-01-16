using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;

namespace BDSBanGap.Controllers
{ 
    public class ProductController : BaseController
    {
        //
        // GET: /Product/

        public ViewResult Index()
        {
            var products = db.Products.Include(p => p.Ward).Include(p => p.Contact);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName");
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName");
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName", product.WardID);
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName", product.ContactId);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName", product.WardID);
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName", product.ContactId);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName", product.WardID);
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName", product.ContactId);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}