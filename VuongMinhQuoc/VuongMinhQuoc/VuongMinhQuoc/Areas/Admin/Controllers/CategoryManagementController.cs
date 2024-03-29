﻿using System;
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
    public class CategoryManagementController : Controller
    {
        private ProjectDbContextcs db = new ProjectDbContextcs();

        //
        // GET: /Admin/CategoryManagement/

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        
        //
        // GET: /Admin/CategoryManagement/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CategoryManagement/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category category, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        //
        // GET: /Admin/CategoryManagement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }           
            return View(category);
        }

        //
        // POST: /Admin/CategoryManagement/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Admin/CategoryManagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Admin/CategoryManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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