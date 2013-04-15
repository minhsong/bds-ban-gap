using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;
using BDSBanGap.Security;
using NhaChoThue.Models.Enum;

namespace BDSBanGap.Controllers
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
            ViewBag.NhaUuTien = (from s in db.Products.AsEnumerable()
                                 where s.IsCurrentPriority()
                                 && s.IsDelete == false
                                 && s.IsHired == false
                                 select s).OrderByDescending(s => s.ProductID).Take(6);

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
