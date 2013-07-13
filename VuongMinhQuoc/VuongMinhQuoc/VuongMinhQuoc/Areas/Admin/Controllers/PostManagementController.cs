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
    public class PostManagementController : Controller
    {
        private ProjectDbContextcs db = new ProjectDbContextcs();
        public bool HasFile(HttpPostedFileBase file)
        {

            return (file != null && file.ContentLength > 0) ? true : false;

        }
        //
        // GET: /Admin/PostManagement/

        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        //
        // GET: /Admin/PostManagement/Create

        public ActionResult Create()
        {
            ViewBag.TypeList = new SelectList(db.Categories.Where(s => s.Type == "post").ToList(), "Id", "Name");
            return View();
        }

        //
        // POST: /Admin/PostManagement/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Post post, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //product.UpdatedBy = User.Identity.Name;
                post.UpdatedDate = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();

                int orderCaption = 1;
                foreach (var file in files)
                {

                    if (!HasFile(file))
                    {
                        orderCaption++;
                        continue;
                    }

                    if ((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") ||
                        (file.ContentType == "image/png" || (file.ContentType == "image/jpg")))//check allow jpg, gif, png, jpeg
                    {
                        // make thumb image
                        Image image = Image.FromStream(file.InputStream);                      
                        // make projet image - product detail page
                        Bitmap projectImage = new Bitmap(image);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var pathImageProject = Path.Combine(Server.MapPath("~/Upload/PostImage/"), fileName);        

                        //Save image to ProjectImages folder
                        projectImage.Save(pathImageProject);

                        // Set ProjectImage model
                        post.Image = "/Upload/PostImage/" + fileName;

                        // Insert project image to db
                        db.SaveChanges();

                        orderCaption++;// update order
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.TypeList = new SelectList(db.Categories.Where(s => s.Type == "post").ToList(), "Id", "Name");
            return View(post);
        }
        //
        // GET: /Admin/PostManagement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeList = new SelectList(db.Categories.Where(s => s.Type == "post").ToList(), "Id", "Name",post.CategoryId);
            return View(post);
        }

        //
        // POST: /Admin/PostManagement/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Post post, IEnumerable<HttpPostedFileBase> files, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var oldPost = db.Posts.Find(post.Id);
                if (System.IO.File.Exists(Server.MapPath(oldPost.Image)))
                {
                    System.IO.File.Delete(Server.MapPath(oldPost.Image));
                }

                oldPost.Title = post.Title;
                oldPost.Body = post.Body;
                oldPost.CategoryId = post.CategoryId;
                oldPost.Conclusion = post.Conclusion;
                int orderCaption = 1;
                foreach (var file in files)
                {

                    if (!HasFile(file))
                    {
                        orderCaption++;
                        continue;
                    }                    

                    if ((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") ||
                        (file.ContentType == "image/png" || (file.ContentType == "image/jpg")))//check allow jpg, gif, png, jpeg
                    {
                        // make thumb image
                        Image image = Image.FromStream(file.InputStream);
                        // make projet image - product detail page
                        Bitmap projectImage = new Bitmap(image);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var pathImageProject = Path.Combine(Server.MapPath("~/Upload/PostImage/"), fileName);

                        //Save image to ProjectImages folder
                        projectImage.Save(pathImageProject);

                        // Set ProjectImage model
                        oldPost.Image = "/Upload/PostImage/" + fileName;

                        // Insert project image to db                     
                        db.SaveChanges();

                        orderCaption++;// update order
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.TypeList = new SelectList(db.Categories.Where(s => s.Type == "post").ToList(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        //
        // GET: /Admin/PostManagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Admin/PostManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            if (System.IO.File.Exists(Server.MapPath(post.Image)))
            {
                System.IO.File.Delete(Server.MapPath(post.Image));
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