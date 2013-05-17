using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaChoThue.Models.DBContext;

namespace NhaChoThue.Controllers
{
    [Authorize]
    public class MasterDataController : BaseController
    {
        //
        // GET: /MasterData/

        #region Contact

        public ActionResult ListContacts()
        {
            return View(db.Contacts.ToList().OrderBy(s=>s.FullName));
        }

        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedBy = User.Identity.Name;
                contact.CreatedDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                contact.UpdatedDate = DateTime.Now;
                contact.IsDelete = false;
                db.Entry(contact).State = System.Data.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("ListContacts");
            }
            return View(contact);
        }

        public ActionResult EditContact(int id)
        {
            var ct = db.Contacts.Find(id);
            return PartialView(ct);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var ct = db.Contacts.Find(contact.ContactID);
                if (ct != null)
                {
                    ct.FullName = contact.FullName;
                    ct.Phone = contact.Phone;
                    ct.Email = contact.Email;
                    ct.Address = contact.Address;
                    ct.UpdatedBy = User.Identity.Name;
                    ct.UpdatedDate = DateTime.Now;
                    db.Entry(ct).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteContact(int id)
        {
            return View();
        }

        #endregion

        #region Wards

        public ActionResult CreateWard()
        {
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateWard(Ward ward)
        {
            if (ModelState.IsValid)
            {
                ward.CreatedBy = User.Identity.Name;
                ward.CreatedDate = DateTime.Now;
                ward.UpdatedBy = User.Identity.Name;
                ward.UpdatedDate = DateTime.Now;
                ward.IsDelete = false;
                db.Entry(ward).State = System.Data.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("DistrictDetail", new { id = ward.DistrictID});
            }
            return View();
        }

        public ActionResult EditWard(int id)
        {
            var ward = db.Wards.Find(id);
            ViewBag.district = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName", ward.DistrictID);
            return PartialView(ward);
        }

        [HttpPost]
        public ActionResult EditWard(Ward ward)
        {
            if (ModelState.IsValid)
            {
                var editWard = db.Wards.Find(ward.WardID);
                editWard.UpdatedBy = User.Identity.Name;
                editWard.UpdatedDate = DateTime.Now;
                editWard.Description = ward.Description;
                editWard.DistrictID = ward.DistrictID;
                editWard.WardName = ward.WardName;
                db.Entry(editWard).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return null;
            }
            ViewBag.district = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName", ward.DistrictID);
            return View(ward);
        }

        [HttpPost]
        public ActionResult DeleteWard(int id)
        {
            var ward = db.Wards.Find(id);
            if (ward != null)
            {
                db.Entry(ward).State = System.Data.EntityState.Deleted;
                db.SaveChanges();
            }
            return null;
        }

        #endregion

        #region District
        public ActionResult DistrictDetail(int id)
        {
            var dt = db.Districts.Find(id);
            return View(dt);
        }

        public ActionResult ListDistricts()
        {
            return View(db.Districts.ToList().OrderBy(s => s.DistrictName));
        }

        public ActionResult CreateDistrict()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                district.CreatedBy = User.Identity.Name;
                district.CreatedDate = DateTime.Now;
                district.UpdatedBy = User.Identity.Name;
                district.UpdatedDate = DateTime.Now;
                district.IsDelete = false;
                db.Entry(district).State = System.Data.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("ListDistricts");
            }
            return View(district);
        }


        public ActionResult EditDistrict(int id)
        {
            var dt = db.Districts.Find(id);
            return PartialView(dt);
        }

        [HttpPost]
        public ActionResult EditDistrict(District district)
        {
            var ds = db.Districts.Find(district.DistrictID);
            if (ds != null)
            {
                ds.DistrictName = district.DistrictName;
                ds.Description = district.Description;
                ds.UpdatedBy = User.Identity.Name;
                ds.UpdatedDate = DateTime.Now;
                db.Entry(ds).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return null;
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteDistrict(int id)
        {
            var dis = db.Districts.Find(id);
            if (dis != null)
            {
                db.Entry(dis).State = System.Data.EntityState.Deleted;
                db.SaveChanges();
            }
            return null;
        }

        #endregion

    }
}
