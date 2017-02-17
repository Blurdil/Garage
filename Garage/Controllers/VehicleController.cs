using Garage.DAL;
using Garage.Models;
using Garage.Models.ViewModels.VehicleViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class VehicleController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicle
        public ActionResult Search(string orderBy, string sortOrder, string searchTerm)
        {
            if (sortOrder != "desc")
            {
                ViewBag.SortOrder = "desc";
            }

            IQueryable<Vehicle> Vehicles = db.Vehicles;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                Vehicles = Vehicles.Where(x => x.Color.Contains(searchTerm) ||
                x.Fabricate.Contains(searchTerm) ||
                x.FabricateModel.Contains(searchTerm) ||
                x.RegNr.Contains(searchTerm) ||
                x.VehicleType.Type.Contains(searchTerm)
                );
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "color":
                        if (sortOrder == "desc")
                        {
                            Vehicles = Vehicles.OrderByDescending(x => x.Color);
                        }
                        else
                        {
                            Vehicles = Vehicles.OrderBy(x => x.Color);
                        }
                        break;

                    case "fabricate":
                        if (sortOrder == "desc")
                        {
                            Vehicles = Vehicles.OrderByDescending(x => x.Fabricate);
                        }
                        else
                        {
                            Vehicles = Vehicles.OrderBy(x => x.FabricateModel);
                        }
                        break;

                    case "regnr":
                        if (sortOrder == "desc")
                        {
                            Vehicles = Vehicles.OrderByDescending(x => x.RegNr);
                        }
                        else
                        {
                            Vehicles = Vehicles.OrderBy(x => x.RegNr);
                        }
                        break;

                    default:
                        if (sortOrder == "desc")
                        {
                            Vehicles = Vehicles.OrderByDescending(x => x.VehicleType.Type);
                        }
                        else
                        {
                            Vehicles = Vehicles.OrderBy(x => x.VehicleType.Type);
                        }
                        break;
                }
            }

            VehicleShowViewModel model = new VehicleShowViewModel();
            model.Vehicles = model.ListViewModel(Vehicles.ToList());
            return View(model);
        }
    }
}