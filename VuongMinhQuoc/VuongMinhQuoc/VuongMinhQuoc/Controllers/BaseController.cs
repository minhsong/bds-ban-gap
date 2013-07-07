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

    }
}
