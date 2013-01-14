using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDSBanGap.Models.DBContext;

namespace BDSBanGap.Controllers
{
    public class BaseController : Controller
    {
        protected BDSDBContext db = new BDSDBContext();

        protected override void ExecuteCore()
        {
            base.ExecuteCore();
        }

    }
}
