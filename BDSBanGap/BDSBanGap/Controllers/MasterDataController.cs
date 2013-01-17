using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;

namespace BDSBanGap.Controllers
{
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
                db.Entry(contact).State = System.Data.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("ListContacts");
            }
            return View(contact);
        }

        public ActionResult EditContact(int id)
        {
            var ct = db.Contacts.Find(id);
            return View(ct);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
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
            return View();
        }

        public ActionResult EditWard(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditWard(Ward ward)
        {
            return View();
        }

        public ActionResult DeleteWard(int id)
        {
            return View();
        }

        #endregion

        #region District

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
                db.Entry(district).State = System.Data.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("ListDistricts");
            }
            return View(district);
        }

        public ActionResult EditDistrict(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditDistrict(District district)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteDistrict(int id)
        {
            return View();
        }

        #endregion

    }
}
