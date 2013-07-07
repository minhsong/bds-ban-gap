using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuongMinhQuoc.Models.DBContext;

namespace VuongMinhQuoc.Controllers
{
    public class BaseController : Controller
    {

        protected ProjectDbContextcs db = new ProjectDbContextcs();
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            ViewBag.years = (from s in db.Products select s.Year).Distinct();
            return base.BeginExecute(requestContext, callback, state);
        }

    }
}
