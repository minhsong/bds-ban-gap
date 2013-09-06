using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhaChoThue.Models.DBContext;
using NhaChoThue.Security;
using NhaChoThue.Models.Enum;

namespace NhaChoThue.Controllers
{
    [ValidateInput(false)]
    public class BaseController : Controller
    {
        protected BDSDBContext db = new BDSDBContext();

        protected virtual new UserPrincipal User
        {
            get { return HttpContext.User as UserPrincipal; }
        }

        [NonAction]
        protected ActionResult Error(Exception ex)
        {
            HandleErrorInfo er = new HandleErrorInfo(ex, HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString(), HttpContext.Request.RequestContext.RouteData.Values["Action"].ToString());

            return View("Error",er);
        }
        
        protected override void ExecuteCore()
        {
            
            
            ViewBag.DisctrictSearch = new SelectList(db.Districts, "DistrictID", "DistrictName");
            var list = (from s in db.Products
                        where !s.IsHired
                        && s.IsActive
                        && !s.IsDelete
                        && s.Priorities.Count>0
                        select s).ToList();
            ViewBag.NhaUuTien = (from s in list.AsEnumerable()
                                 where s.IsCurrentPriority()
                                 select s).OrderByDescending(s => s.ProductID).Take(6).ToList();

            try
            {

                ViewBag.pricesFrom = new SelectList(Prices.GetPriceFrom(), "ItemValue", "DisplayValue", Request.Params["From"]);
                ViewBag.PricesTo = new SelectList(Prices.GetPriceTo(), "ItemValue", "DisplayValue", Request.Params["To"]);
            }
            catch { }
            base.ExecuteCore();
        }

    }
}
