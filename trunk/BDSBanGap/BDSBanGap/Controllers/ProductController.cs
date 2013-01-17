using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;
using BDSBanGap.Models.Enum;
using System.Drawing;
using System.IO;

namespace BDSBanGap.Controllers
{ 
    [ValidateInput(false)]
    public class ProductController : BaseController
    {
        public bool HasFile(HttpPostedFileBase file)
        {

            return (file != null && file.ContentLength > 0) ? true : false;

        }
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
        [Authorize]
        public ActionResult CreateGet()
        {
            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName");
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName");
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue");
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue");
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue");
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue");
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName");
            return View("Create");
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int productID;
                int orderCaption = 1;
                //Create project
                product.CreatedBy = User.Identity.Name;
                product.CreatedDate = DateTime.Now;
                product.UpdatedBy = User.Identity.Name;
                product.UpdatedDate = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();

                productID = product.ProductID;


                foreach (var file in files)
                {

                    if (!HasFile(file))
                    {
                        orderCaption++;
                        continue;
                    }

                    ProductImage proImage = new ProductImage();

                    if ((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") ||
                        (file.ContentType == "image/png" || (file.ContentType == "image/jpg")))//check allow jpg, gif, png, jpeg
                    {
                        // make thumb image
                        Image image = Image.FromStream(file.InputStream);
                        Bitmap thumbImage = new Bitmap(image, 120, 90);

                        // make projet image - product detail page
                        Bitmap projectImage = new Bitmap(image, 480, 360);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var pathImageProject = Path.Combine(Server.MapPath("~/Upload/Images/"), fileName);
                        var pathImageThumb = Path.Combine(Server.MapPath("~/Upload/Thumb/"), fileName);

                        //Save image to ProjectImages folder
                        projectImage.Save(pathImageProject);

                        // Save image to ImageThumb folder
                        thumbImage.Save(pathImageThumb);

                        // Save slide image to ImageSlide

                        // Set ProjectImage model
                        proImage.ImageLink = "/Upload/Images/" + fileName;
                        proImage.Caption = collection["caption" + orderCaption];
                        proImage.ThumblLink = "/Upload/Thumb/" + fileName;

                        proImage.ProductID = productID;

                        // Insert project image to db
                        db.ProductImages.Add(proImage);//add Image object to database (content image path)
                        db.SaveChanges();

                        orderCaption++;// update order
                    }

                }

                return RedirectToAction("Index");  
            }

            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName", product.WardID);
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactID", "FullName", product.ContactId);
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",product.Huong);
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",product.LoaiDiaOc);
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",product.TinhTrangPhapLy);
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",product.ViTriDiaOc);
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName");
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

        public ActionResult GetWardOnChange(int district)
        {
            ViewBag.Ward = new SelectList(from s in db.Wards where s.DistrictID == district select s, "WardID", "WardName");
            return PartialView("WardsArea");
        }
    }
}