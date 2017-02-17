using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class VehicleDetailViewModel
    {
        [Display(Name = "Registerings Nummer")]
        public string RegNr { get; set; }
        [Display(Name = "Färg")]
        public string Color { get; set; }
        [Display(Name = "Märke")]
        public string Fabricate { get; set; }
        [Display(Name = "Model")]
        public string FabricateModel { get; set; }
        [Display(Name = "Fordon Typ")]
        public string VehicleType { get; set; }
        [Display(Name = "Ägare")]
        public string Owner { get; set; }
        [Display(Name = "Antal hjul")]
        public int NumberOfTyres { get; set; }

        public VehicleDetailViewModel toViewModel(Vehicle vehicle)
        {
            VehicleDetailViewModel model = new VehicleDetailViewModel
            {
                Color = vehicle.Color,
                RegNr = vehicle.RegNr,
                Fabricate = vehicle.Fabricate,
                FabricateModel = vehicle.FabricateModel,
                VehicleType = vehicle.VehicleType.Type,
                NumberOfTyres = vehicle.VehicleType.NumberOfTyre,
                Owner = vehicle.Member.FirstName + " " + vehicle.Member.LastName,
            };
            return model;
        }
    }
}