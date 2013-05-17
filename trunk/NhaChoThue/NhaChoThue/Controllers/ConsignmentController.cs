using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaChoThue.Controllers
{
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

    }
}
