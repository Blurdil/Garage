using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.VehicleViews
{
    public class VehicleShowViewModel
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
        [Display(Name = "Fordon Typ")]
        public string VehicleType { get; set; }
        public IList<VehicleShowViewModel> Vehicles { get; set; }

        public IList<VehicleShowViewModel> ListViewModel(List<Vehicle> vehicles)
        {
            VehicleShowViewModel model = new VehicleShowViewModel();
            model.Vehicles = new List<VehicleShowViewModel>();
            foreach(var vehicle in vehicles)
            {
                VehicleShowViewModel m = new VehicleShowViewModel
                {
                    Color = vehicle.Color,
                    Fabricate = vehicle.Fabricate,
                    FabricateModel = vehicle.FabricateModel,
                    Regnr = vehicle.RegNr,
                    VehicleType = vehicle.VehicleType.Type
                };
                model.Vehicles.Add(m);
            }
            return model.Vehicles;
        }
    }
}