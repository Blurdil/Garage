using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.VehicleViews
{
    public class VehicleShowViewModel
    {
        public int id { get; set; }
        public string Color { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
        public string Regnr { get; set; }
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