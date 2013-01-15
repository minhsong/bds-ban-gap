using System;
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

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }

    }
}
