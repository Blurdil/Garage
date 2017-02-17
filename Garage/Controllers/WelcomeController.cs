using Garage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class WelcomeController : Controller
    {
        private GarageContext db = new GarageContext();
        // GET: Welcome
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int MemberNr)
        {
            var member = db.Members.Find(MemberNr);
            if(member != null)
            {
                return RedirectToAction("Index", "Member", new { id = MemberNr });
            }
            ViewBag.ErrorMessage = "Ingen medlem med det numret hittades.";
            return View();
        }
    }
}