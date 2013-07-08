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

namespace VuongMinhQuoc.Areas.Admin.Controllers
{
    public class ProductManagementController : Controller
    {

        protected ProjectDbContextcs db = new ProjectDbContextcs();
        public bool HasFile(HttpPostedFileBase file)
        {

            return (file != null && file.ContentLength > 0) ? true : false;

        }
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.TypeList = new SelectList(db.Types.ToList(), "Id", "name");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //product.CreatedBy = User.Identity.Name;
                product.CreatedDate = DateTime.Now;
                // product.UpdatedBy = User.Identity.Name;
                product.UpdatedDate = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();

                int orderCaption = 1;
                foreach (var file in files)
                {

                    if (!HasFile(file))
                    {
                        orderCaption++;
                        continue;
                    }

                    ProductImages proImage = new ProductImages();

                    if ((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") ||
                        (file.ContentType == "image/png" || (file.ContentType == "image/jpg")))//check allow jpg, gif, png, jpeg
                    {
                        // make thumb image
                        Image image = Image.FromStream(file.InputStream);
                        Bitmap thumbImage = new Bitmap(image, 270, 134);
                        // make projet image - product detail page
                        Bitmap projectImage = new Bitmap(image);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var pathImageProject = Path.Combine(Server.MapPath("~/Upload/Images/"), fileName);
                        var pathImageThumb = Path.Combine(Server.MapPath("~/Upload/Thumb/"), fileName);

                        // Save image to ImageThumb folder
                        thumbImage.Save(pathImageThumb);

                        //Save image to ProjectImages folder
                        projectImage.Save(pathImageProject);

                        // Set ProjectImage model
                        proImage.Link = "/Upload/Images/" + fileName;
                        proImage.Caption = collection["caption" + orderCaption];
                        proImage.ThumbLink = "/Upload/Thumb/" + fileName;

                        proImage.ProductId = product.Id;

                        // Insert project image to db
                        db.ProductImages.Add(proImage);//add Image object to database (content image path)
                        db.SaveChanges();

                        orderCaption++;// update order
                    }

                }

                return RedirectToAction("Index");
            }
            ViewBag.TypeList = new SelectList(db.Types.ToList(), "Id", "name");
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeList = new SelectList(db.Types.ToList(), "Id", "name", product.TypeId);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //product.UpdatedBy = User.Identity.Name;
                product.UpdatedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                int orderCaption = 1;
                foreach (var file in files)
                {

                    if (!HasFile(file))
                    {
                        orderCaption++;
                        continue;
                    }

                    ProductImages proImage = new ProductImages();

                    if ((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") ||
                        (file.ContentType == "image/png" || (file.ContentType == "image/jpg")))//check allow jpg, gif, png, jpeg
                    {
                        // make thumb image
                        Image image = Image.FromStream(file.InputStream);
                        Bitmap thumbImage = new Bitmap(image, 270, 134);
                        // make projet image - product detail page
                        Bitmap projectImage = new Bitmap(image);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var pathImageProject = Path.Combine(Server.MapPath("~/Upload/Images/"), fileName);
                        var pathImageThumb = Path.Combine(Server.MapPath("~/Upload/Thumb/"), fileName);

                        // Save image to ImageThumb folder
                        thumbImage.Save(pathImageThumb);

                        //Save image to ProjectImages folder
                        projectImage.Save(pathImageProject);

                        // Set ProjectImage model
                        proImage.Link = "/Upload/Images/" + fileName;
                        proImage.Caption = collection["caption" + orderCaption];
                        proImage.ThumbLink = "/Upload/Thumb/" + fileName;

                        proImage.ProductId = product.Id;

                        // Insert project image to db
                        db.ProductImages.Add(proImage);//add Image object to database (content image path)
                        db.SaveChanges();

                        orderCaption++;// update order
                    }


                    return RedirectToAction("Index");
                }
            }
            ViewBag.TypeList = new SelectList(db.Types.ToList(), "Id", "name", product.TypeId);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            var imagedelllist = product.Imanges.ToList();
            List<ProductImages> imagelist = new List<ProductImages>();
            foreach (var item in imagedelllist)
            {
                db.Entry(item).State = EntityState.Deleted;
                imagelist.Add(item);
            }
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
            foreach (var item in imagelist)
            {
                System.IO.File.Delete(Server.MapPath(item.ThumbLink));
                System.IO.File.Delete(Server.MapPath(item.Link));
            }


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
