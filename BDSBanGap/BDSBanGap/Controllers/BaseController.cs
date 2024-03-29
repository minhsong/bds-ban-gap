﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;
using BDSBanGap.Security;

namespace BDSBanGap.Controllers
{
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
                                && s.IsDelete==false
                                && s.IsSold ==false
                                select s).OrderByDescending(s=>s.CurrentPriority().EndDate.Value).Take(5);
            base.ExecuteCore();
        }

    }
}
