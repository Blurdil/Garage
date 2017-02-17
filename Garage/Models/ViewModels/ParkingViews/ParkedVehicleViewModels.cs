using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage.Models;
using System.ComponentModel.DataAnnotations;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class ParkedVehicleViewModels
    {
        public int id { get; set; }
        [Display(Name = "Färg")]
        public string Color { get; set; }
        [Display(Name = "Märke")]
        public string Fabricate { get; set; }
        [Display(Name = "Model")]
        public string FabricateModel { get; set; }
        [Display(Name = "Registrerings Nummer")]
        public string Regnr { get; set; }
        [Display(Name = "Fordon typ")]
        public string VehicleType { get; set; }
        [Display(Name = "Ägare")]
        public string Owner { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Parkering Startad")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd HH:mm}")]
        public DateTime ParkTimeStart { get; set; }
        public IList<ParkedVehicleViewModels> Vehicles { get; set; }

        public IList<ParkedVehicleViewModels> ListViewModel(List<Vehicle> vehicles)
        {
            ParkedVehicleViewModels model = new ParkedVehicleViewModels();
            model.Vehicles = new List<ParkedVehicleViewModels>();
            foreach (var vehicle in vehicles)
            {
                ParkedVehicleViewModels m = new ParkedVehicleViewModels
                {
                    ParkTimeStart = vehicle.StartParkingTime,
                    Color = vehicle.Color,
                    Fabricate = vehicle.Fabricate,
                    FabricateModel = vehicle.FabricateModel,
                    Regnr = vehicle.RegNr,
                    VehicleType = vehicle.VehicleType.Type,
                    Owner = vehicle.Member.FirstName + " " + vehicle.Member.LastName,
                    OwnerId = vehicle.Member.Id,
                };
                model.Vehicles.Add(m);
            }
            return model.Vehicles;
        }
    }
}