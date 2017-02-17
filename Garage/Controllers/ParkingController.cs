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

            IQueryable<Parking> parking = db.Parkings;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                parking = parking.Where(x => x.Member.FirstName.Contains(searchTerm) ||
                x.Member.LastName.Contains(searchTerm) ||
                x.Vehicle.VehicleType.Type.Contains(searchTerm) ||
                x.Vehicle.RegNr.Contains(searchTerm)
                );
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "firstname":
                        if (sortOrder == "desc")
                        {
                            parking = parking.OrderByDescending(x => x.Member.FirstName);
                        }
                        else
                        {
                            parking = parking.OrderBy(x => x.Member.FirstName);
                        }
                        break;

                    case "fabricate":
                        if (sortOrder == "desc")
                        {
                            parking = parking.OrderByDescending(x => x.Vehicle.Fabricate);
                        }
                        else
                        {
                            parking = parking.OrderBy(x => x.Vehicle.Fabricate);
                        }
                        break;

                    case "regnr":
                        if (sortOrder == "desc")
                        {
                            parking = parking.OrderByDescending(x => x.Vehicle.RegNr);
                        }
                        else
                        {
                            parking = parking.OrderBy(x => x.Vehicle.RegNr);
                        }
                        break;

                    default:
                        if (sortOrder == "desc")
                        {
                            parking = parking.OrderByDescending(x => x.Vehicle.VehicleType.Type);
                        }
                        else
                        {
                            parking = parking.OrderBy(x => x.Vehicle.VehicleType.Type);
                        }
                        break;
                }
                }
            else
            {
                if(sortOrder == "desc")
                {
                    parking = parking.OrderByDescending(x => x.StartParkingTime);
                }
                else
                {
                    parking = parking.OrderBy(x => x.StartParkingTime);
                }
            }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park(ParkingFormViewModel model, int MemberId)
        {
            Vehicle vehicle = new ParkingFormViewModel().ToVehicle(model);
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
            var parkings = db.Parkings.ToList();
            Parking parking = new Parking
            {
                MemberId = MemberId,
                StartParkingTime = DateTime.Now,
                VehicleId = vehicle.Id,
                ParkingLot = new ParkingService().FirstFreeParking(parkings)
            };
            db.Parkings.Add(parking);
            db.SaveChanges();
            return RedirectToAction("Index", "Member", new { id = MemberId });
        }

        public ActionResult Checkout(string RegNr)
        {
            ViewBag.Reg = RegNr;
            return View();
        }

        public ActionResult Recipt(string RegNr, bool CreateRecipt = true)
        {
            var parking = db.Parkings.Where(x => x.Vehicle.RegNr == RegNr).SingleOrDefault();
            ReciptViewModel model = new ReciptViewModel();
            model = model.toViewModel(parking);
            ViewBag.MemberId = parking.MemberId;
            db.Parkings.Remove(parking);
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