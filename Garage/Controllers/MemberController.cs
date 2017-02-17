using Garage.DAL;
using Garage.Models;
using Garage.Models.ViewModels.MemberView;
using Garage.Models.ViewModels.MemberViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class MemberController : Controller
    {
        private GarageContext db = new GarageContext();
        // GET: Member
        public ActionResult Index(int id)
        {
            var member = db.Members.Find(id);
            MemberViewModel model = new MemberViewModel().toViewModel(member);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Member member = model.toEntity(model);
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = member.Id });
            }
            ModelState.AddModelError("", "Kunde inte spara till databasen.");
            return View(model);
        }

        public ActionResult ShowMembers(string orderBy, string sortOrder, string searchTerm)
        {
            if(sortOrder != "desc")
            {
                ViewBag.SortOrder = "desc";
            }
            
            IQueryable<Member> members = db.Members;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                members = members.Where(x => x.FirstName.Contains(searchTerm) ||
                x.LastName.Contains(searchTerm) ||
                x.Email.Contains(searchTerm)
                );
            }
            if(!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "firstname":
                        if (sortOrder == "desc")
                        {
                            members = members.OrderByDescending(x => x.FirstName);
                        }
                        else
                        {
                            members = members.OrderBy(x => x.FirstName);
                        }
                        break;

                    case "lastname":
                        if (sortOrder == "desc")
                        {
                            members = members.OrderByDescending(x => x.LastName);
                        }
                        else
                        { 
                        members = members.OrderBy(x => x.LastName);
                        }
                        break;

                    case "email":
                        if (sortOrder == "desc")
                        {
                            members = members.OrderByDescending(x => x.Email);
                        }
                        else
                        {
                            members = members.OrderBy(x => x.Email);
                        }
                        break;

                    default:
                        if (sortOrder == "desc")
                        {
                            members = members.OrderByDescending(x => x.Id);
                        }
                        else
                        {
                            members = members.OrderBy(x => x.Id);
                        }
                        break;
                }
            }

            ShowMemberViewModel model = new ShowMemberViewModel();
            model = model.toViewModel(members.ToList());
            return View(model);
        }
    }
}