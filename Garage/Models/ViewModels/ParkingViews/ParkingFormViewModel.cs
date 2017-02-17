using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class ParkingFormViewModel
    {
        [Required(ErrorMessage = "Måste ange Registrerings Nummer")]
        [Display(Name = "Registrerings Nummer")]
        [RegularExpression("^[A-Z]{3} [0-9]{3}", ErrorMessage = "Fel format. Ska vara AAA 000")]
        [Remote("CheckRegNr", "Validate", ErrorMessage = "Fordonet är redan parkerad.")]
        public string RegNr { get; set; }

        [Display(Name = "Färg")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Måste ange ett märke")]
        [Display(Name ="Märke")]
        public string Fabricate { get; set; }

        [Required(ErrorMessage = "Måste ange en model")]
        [Display(Name = "Model")]
        public string FabricateModel { get; set; }

        [Required(ErrorMessage = "Måste ange vad det är för typ av fordon")]
        [Display(Name = "Fordon Typ")]
        public int Type { get; set; }
        public IList<VehicleType> VehicleType { get; set; }

        public Vehicle ToVehicle(ParkingFormViewModel model)
        {
            Vehicle vehicle = new Vehicle
            {
                RegNr = model.RegNr,
                Color = model.Color,
                Fabricate = model.Fabricate,
                FabricateModel = model.FabricateModel,
                VehicleTypeId = model.Type,
            };
            return vehicle;
        }
    }
}