﻿using System;
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
using BDSBanGap.Models;

namespace BDSBanGap.Controllers
{ 
    [ValidateInput(false)]
    [Authorize]
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
            var product = from product1 in db.Products
                          where product1.IsDelete == false
                          select product1;
            
            return View(product.ToList().OrderByDescending(s=>s.CreatedDate));
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View("/Home/DetailProduct", product);
        }

        //
        // GET: /Product/Create
        [Authorize]
        public ActionResult CreateGet()
        {
            var fisrtDis = db.Districts.First();
            ViewBag.WardID = new SelectList(fisrtDis.Wards, "WardID", "WardName", fisrtDis.Wards.First().WardID);
            ViewBag.Contact = new SelectList(db.Contacts, "ContactID", "FullName");
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue");
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue");
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue");
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue");
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",fisrtDis.DistrictID);
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
                product.IsActive = true;
                product.IsDelete = false;
                product.IsSold = false;

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
            int districtid = db.Wards.Find(product.WardID).DistrictID;
            ViewBag.WardID = new SelectList(db.Wards.Where(w=>w.DistrictID==districtid) , "WardID", "WardName", product.WardID);
            ViewBag.Contact = new SelectList(db.Contacts, "ContactID", "FullName", product.ContactId);
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",product.Huong);
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",product.LoaiDiaOc);
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",product.TinhTrangPhapLy);
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",product.ViTriDiaOc);
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",districtid);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.Wards = new SelectList(product.Ward.District.Wards.ToList(), "WardID", "WardName",product.WardID);
            ViewBag.Contacts = new SelectList(db.Contacts, "ContactID", "FullName",product.ContactId);
            ViewBag.Huongs = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",product.Huong);
            ViewBag.LoaiDiaOcs = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",product.LoaiDiaOc);
            ViewBag.Phaplies = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",product.TinhTrangPhapLy);
            ViewBag.VitriDiaOcs = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",product.ViTriDiaOc);
            ViewBag.Districts = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",product.Ward.DistrictID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int productID;
                int orderCaption = 1;
                //Create project
                var producrsave = db.Products.Find(product.ProductID);
                if (producrsave != null)
                {
                    producrsave.UpdatedBy = User.Identity.Name;
                    producrsave.UpdatedDate = DateTime.Now;

                    producrsave.ChoDauXeHoi = product.ChoDauXeHoi;
                    producrsave.ChoSinhVienThue = product.ChoSinhVienThue;
                    producrsave.CNDai  = product.CNDai;
                    producrsave.CNNgangSau = product.CNNgangSau;
                    producrsave.CNNgangTruoc = product.CNNgangTruoc; 
                    producrsave.ContactId = product.ContactId;
                    producrsave.DayDuTienNghi = product.DayDuTienNghi;
                    producrsave.Description = product.Description;
                    producrsave.DienTichSuDung = product.DienTichSuDung;
                    producrsave.DuongTruocNha = product.DuongTruocNha; 
                    producrsave.HoBoi = product.HoBoi;
                    producrsave.Huong = product.Huong;
                    producrsave.KVDai = product.KVDai;
                    producrsave.KVNgangSau = product.KVNgangSau;
                    producrsave.KVNgangTruoc = product.KVNgangTruoc;
                    producrsave.LoaiDiaOc = product.LoaiDiaOc;
                    producrsave.Price = product.Price;
                    producrsave.SanVuon = product.SanVuon;
                    producrsave.SoLau = product.SoLau;
                    producrsave.SoPhongKhac = product.SoPhongKhac;
                    producrsave.SoPhongNgu = product.SoPhongNgu;
                    producrsave.SoPhongTam = product.SoPhongTam;
                    producrsave.TienDeO = product.TienDeO;
                    producrsave.TienKinhDoanh = product.TienKinhDoanh;
                    producrsave.TienLamVanPhong = product.TienLamVanPhong;
                    producrsave.TienSanXuat = product.TienSanXuat;
                    producrsave.TinhTrangPhapLy = product.TinhTrangPhapLy;
                    producrsave.Title = product.Title;
                    producrsave.ViTriDiaOc = product.ViTriDiaOc;
                    producrsave.WardID = product.WardID;

                    db.Entry(producrsave).State = EntityState.Modified;
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
            }
            ViewBag.WardID = new SelectList(db.Wards, "WardID", "WardName",product.WardID);
            ViewBag.Contact = new SelectList(db.Contacts, "ContactID", "FullName",product.ContactId);
            ViewBag.Huong = new SelectList(huong.GetListHuong(), "ItemValue", "DisplayValue",product.Huong);
            ViewBag.LoaiDiaOc = new SelectList(LoaiDiaOc.GetListLoaiDiaOc(), "ItemValue", "DisplayValue",product.LoaiDiaOc);
            ViewBag.Phaply = new SelectList(TinhTrangPhapLy.GetListTinhTrangPhapLy(), "ItemValue", "DisplayValue",product.TinhTrangPhapLy);
            ViewBag.VitriDiaOc = new SelectList(ViTriDiaOc.GetListViTriDiaOc(), "ItemValue", "DisplayValue",product.ViTriDiaOc);
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName",product.Ward.DistrictID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id, string page)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                product.IsDelete = true;
                db.SaveChanges();
            }
            //return View(product);
            return RedirectToAction(page);
        }

        public ActionResult Undeleted(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                product.IsDelete = false;
                db.SaveChanges();
            }
            return RedirectToAction("DeletedProducts");

        }

        public ActionResult DeleteFull(int id)
        {
            var pro = db.Products.Find(id);
            var images = from s in db.ProductImages
                         where s.ProductID == pro.ProductID
                         select s;
            foreach (var item in images)
            {
                string pathImage = Server.MapPath(item.ImageLink);
                string pathImageThumb = Server.MapPath(item.ThumblLink);

                FileInfo image = new FileInfo(pathImage);
                FileInfo imageThumb = new FileInfo(pathImageThumb);
                
                if (image.Exists)
                {
                    image.Delete();
                }
                if (imageThumb.Exists)
                {
                    imageThumb.Delete();
                }
                db.Entry(item).State = EntityState.Deleted;
            }
            var priorities = from s in db.Priorities
                             where s.ProductID == id
                             select s;

            foreach (var item in priorities)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            db.Entry(pro).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("DeletedProducts");
        }

        public ActionResult DeletedProducts()
        {
            var list = from s in db.Products
                       where s.IsDelete == true
                       select s;
            return View(list);
        }

        //
        // POST: /Product/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    Product product = db.Products.Find(id);
        //    //db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult GetWardOnChange(int district)
        {
            ViewBag.Ward = new SelectList(from s in db.Wards where s.DistrictID == district select s, "WardID", "WardName");
            return PartialView("WardsArea");
        }

        public ActionResult SetPriorityGet(int id)
        {
            PriorityProduct pr = new PriorityProduct()
            {
                ProductID = id
            };
            return PartialView("SetPriority",pr);
        }

        [HttpPost]
        public ActionResult SetPriority(PriorityProduct hp)
        {
            if (ModelState.IsValid)
            {
                hp.CreatedBy = User.Identity.Name;
                hp.CreatedDate = DateTime.Now;
                hp.UpdatedBy = User.Identity.Name;
                hp.UpdatedDate = DateTime.Now;
                hp.IsActive = true;
                hp.IsDelete = false;
                db.Entry(hp).State = EntityState.Added;
                db.SaveChanges();
            }
            return View(hp);
        }

        public ActionResult RemovePriority(int id)
        {
            var pri = db.Priorities.Find(id);
            pri.EndDate = DateTime.Now;
            db.Entry(pri).State = EntityState.Modified;
            db.SaveChanges();
            return null;
        }

        public ActionResult ListPriorityProduct()
        {
            var result = from s in db.Products.AsEnumerable()
                         where s.IsCurrentPriority()
                         && s.IsSold ==false
                         select s;
            return View(result.OrderByDescending(s => s.CreatedDate));
        }

        public ActionResult SoldProducts()
        {
            var result = from s in db.Products
                         where s.IsSold == true
                        && s.IsDelete == false
                         select s;
            return View(result.OrderByDescending(s => s.SoldDate));
        }

        public ActionResult SellingProducts()
        {
            var result = from s in db.Products
                         where (s.IsSold == null || s.IsSold == false)
                         && s.IsDelete == false
                         && s.IsActive == true
                         select s;
            return View(result.OrderByDescending(s => s.CreatedDate));
        }

        public ActionResult DeleteEmage(int id)
        {
            try
            {
                ProductImage proImage = db.ProductImages.Find(id);
                int proID = proImage.ProductID;
                // remove at server
                string pathImage = Server.MapPath(proImage.ImageLink);
                string pathImageThumb = Server.MapPath(proImage.ThumblLink);

                FileInfo image = new FileInfo(pathImage);
                FileInfo imageThumb = new FileInfo(pathImageThumb);

                if (image.Exists)
                {
                    image.Delete();
                }
                if (imageThumb.Exists)
                {
                    imageThumb.Delete();
                }

                // remove at db
                db.ProductImages.Remove(proImage);
                db.SaveChanges();

                return View("Edit", db.Products.Find(proID));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ReplaceEmage(int id)
        {
            var img = db.ProductImages.Find(id);
            return PartialView(img);
        }

        [HttpPost]
        public ActionResult ReplaceEmage(int ProductImageID, string caption, HttpPostedFileBase file)
        {
            var img = db.ProductImages.Find(ProductImageID);
            if (HasFile(file))
            {
                
                img.Caption = caption;
                FileInfo image = new FileInfo(Server.MapPath(img.ImageLink));
                FileInfo imageThumb = new FileInfo(Server.MapPath(img.ThumblLink));
                if (image.Exists)
                {
                    image.Delete();
                }
                if (imageThumb.Exists)
                {
                    imageThumb.Delete();
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var pathImageProject = Path.Combine(Server.MapPath("~/Upload/Images/"), fileName);
                var pathImageThumb = Path.Combine(Server.MapPath("~/Upload/Thumb/"), fileName);
                Image newEmage = Image.FromStream(file.InputStream);
                Bitmap newThumb = new Bitmap(newEmage, 120, 90);

                // make projet image - product detail page
                Bitmap projectImage = new Bitmap(newEmage, 480, 360);

                //Save image to ProjectImages folder
                projectImage.Save(pathImageProject);

                // Save image to ImageThumb folder
                newThumb.Save(pathImageThumb);

                img.ImageLink = "/Upload/Images/" + fileName;
                img.ThumblLink = "/Upload/Thumb/" + fileName;

                db.SaveChanges();
            }
            return RedirectToAction("Edit", new {id= img.ProductID});
        }

        public ActionResult SoldProductGet(int id)
        {
            SoldModel sd = new SoldModel() { ProductID = id };
            return PartialView("SoldProduct",sd);
        }

        [HttpPost]
        public void SoldProduct(SoldModel sold)
        {
            var product = db.Products.Find(sold.ProductID);
            if (product != null)
            {
                product.SoldPrice = sold.soldPrice;
                product.SoldDate = sold.soldeDate;
                product.IsSold = true;
                product.UpdatedBy = User.Identity.Name;
                product.UpdatedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public void NotSoldProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                product.SoldPrice = null;
                product.SoldDate = null;
                product.IsSold = false;
                db.SaveChanges();
            }
        }
    }
}