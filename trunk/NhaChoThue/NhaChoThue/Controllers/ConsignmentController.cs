using NhaChoThue.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaChoThue.Controllers
{
    [Authorize]
    public class ConsignmentController : BaseController
    {
        //
        // GET: /Consignment/

        public ActionResult Index()
        {
            var result = from s in db.Consignments
                         where !s.IsDelete
                         && !s.IsSolved
                         select s;
            return View(result);
        }

        public ActionResult SolvedConsigs()
        {
            var result = from s in db.Consignments
                         where s.IsSolved
                         && !s.IsDelete
                         select s;  
            return View(result);
        }

        public ActionResult Transform(int id)
        {
            Helpers.SessionHelper.SetSession("ConsignmentId", id);
            var consig = db.Consignments.Find(id);
            var trans = new Product(){
                Description = consig.Description,
                Price = consig.Price,
            };
            var fisrtDis = db.Districts.First();
            ViewBag.WardID = new SelectList(fisrtDis.Wards, "WardID", "WardName", fisrtDis.Wards.First().WardID);
            ViewBag.Contact = new SelectList(db.Contacts, "ContactID", "FullName");
            ViewBag.District = new SelectList(db.Districts.ToList(), "DistrictID", "DistrictName", fisrtDis.DistrictID);
            return View(trans);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var consig = db.Consignments.Find(id);
            if (consig != null)
            {
                db.Consignments.Remove(consig);
                db.SaveChanges();
            }
            return Json(new {status = true});
        }

    }
}
