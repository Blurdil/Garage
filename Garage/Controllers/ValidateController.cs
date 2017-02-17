using Garage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class ValidateController : Controller
    {
        private GarageContext db = new GarageContext();
        // GET: Validate
        public ActionResult CheckRegNr(string RegNr)
        {
            bool check = db.Vehicles.Where(x => x.RegNr == RegNr).Any();
            if(!check)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string msg = string.Format("{0} är redan parkerad", RegNr);
            return Json(false, msg, JsonRequestBehavior.AllowGet);
        }
    }
}