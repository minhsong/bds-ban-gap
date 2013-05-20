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
            foreach (var item in result)
            {
                item.Districts = getDistricts(item.Districts);    
            }
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var bk = db.Bookeds.Find(id);
            bk.Districts = getDistricts(bk.Districts);
            return PartialView(bk);
        }

        private string getDistricts(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            string result="";
            foreach (var item in input.Split(';'))
            {
                if (string.IsNullOrEmpty(item)) continue;

                int distId = Convert.ToInt32(item);
                if(distId!=0){
                    result += db.Districts.Find(distId).DistrictName + "; ";
                }
                
            }
            return result;
        }

    }
}
