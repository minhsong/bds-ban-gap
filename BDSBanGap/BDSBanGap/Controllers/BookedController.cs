using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDSBanGap.Controllers
{
    public class BookedController : BaseController
    {
        //
        // GET: /Booked/

        public ActionResult Index()
        {
            var result = from s in db.Bookeds where s.IsSolved == false select s;
            return View(result);
        }

    }
}
