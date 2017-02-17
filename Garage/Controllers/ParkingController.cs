using Garage.DAL;
using Garage.Models;
using Garage.Models.ViewModels.ParkingViews;
using Garage.Models.ViewModels.VehicleViews;
using Garage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Controllers
{
    public class ParkingController : Controller
    {
        private GarageContext db = new GarageContext();
        // GET: Parking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParkedVehicles(string orderBy, string sortOrder, string searchTerm)
        {
            if (sortOrder != "desc")
            {
                ViewBag.SortOrder = "desc";
            }

            IQueryable<Vehicle> vehicles = db.Vehicles;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                vehicles = vehicles.Where(x => x.Member.FirstName.Contains(searchTerm) ||
                x.Member.LastName.Contains(searchTerm) ||
                x.VehicleType.Type.Contains(searchTerm) ||
                x.RegNr.Contains(searchTerm)
                );
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "owner":
                        if (sortOrder == "desc")
                        {
                            vehicles = vehicles.OrderByDescending(x => x.Member.FirstName);
                        }
                        else
                        {
                            vehicles = vehicles.OrderBy(x => x.Member.FirstName);
                        }
                        break;

                    case "parktimestart":
                        if (sortOrder == "desc")
                        {
                            vehicles = vehicles.OrderByDescending(x => x.StartParkingTime);
                        }
                        else
                        {
                            vehicles = vehicles.OrderBy(x => x.StartParkingTime);
                        }
                        break;

                    case "regnr":
                        if (sortOrder == "desc")
                        {
                            vehicles = vehicles.OrderByDescending(x => x.RegNr);
                        }
                        else
                        {
                            vehicles = vehicles.OrderBy(x => x.RegNr);
                        }
                        break;

                    default:
                        if (sortOrder == "desc")
                        {
                            vehicles = vehicles.OrderByDescending(x => x.VehicleType.Type);
                        }
                        else
                        {
                            vehicles = vehicles.OrderBy(x => x.VehicleType.Type);
                        }
                        break;
                }
            }
            else
            {
                    vehicles = vehicles.OrderByDescending(x => x.StartParkingTime);


            }
            ParkedVehicleViewModels model = new ParkedVehicleViewModels();
            model.Vehicles = model.ListViewModel(vehicles.ToList());
            return View(model);
        }
    
        public ActionResult Details(string regNr)
        {
            try
            {
                var vehicle = db.Vehicles.Where(x => x.RegNr == regNr).SingleOrDefault();
                VehicleDetailViewModel model = new VehicleDetailViewModel();
                model = model.toViewModel(vehicle);
                return View(model);
            }
            catch
            {
                ViewBag.Message = "Fordonet hittade inte.";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park(ParkingFormViewModel model, int MemberId)
        {

            var parkingLots = new ParkingService().FreeLots();
            if (parkingLots == 0)
            {
                ModelState.AddModelError("", "Finns inga lediga platser");
            }
            if (ModelState.IsValid)
            {
                var parkings = db.Vehicles.ToList();
                Vehicle vehicle = new Vehicle
                {
                    Color = model.Color,
                    Fabricate = model.Fabricate,
                    FabricateModel = model.FabricateModel,
                    MemberId = MemberId,
                    RegNr = model.RegNr,
                    StartParkingTime = DateTime.Now,
                    VehicleTypeId = model.Type,
                    ParkingLot = new ParkingService().FirstFreeParking(parkings),
                };
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index", "Member", new { id = MemberId });
        }

        public ActionResult Checkout(string RegNr)
        {
            ViewBag.Reg = RegNr;
            return View();
        }

        public ActionResult Recipt(string RegNr, bool CreateRecipt = true)
        {
            var parking = db.Vehicles.Where(x => x.RegNr == RegNr).SingleOrDefault();
            ReciptViewModel model = new ReciptViewModel();
            model = model.toViewModel(parking);
            ViewBag.MemberId = parking.MemberId;
            db.Vehicles.Remove(parking);
            db.SaveChanges();
            if(CreateRecipt == false)
            {
                return RedirectToAction("Index", "Member", new { id = parking.MemberId });
            }

            return View(model);
        }

        public ActionResult ParkingForm()
        {
            ParkingFormViewModel model = new ParkingFormViewModel();
            model.VehicleType = db.VehiclesType.ToList();
            return View(model);
        }
    }
}