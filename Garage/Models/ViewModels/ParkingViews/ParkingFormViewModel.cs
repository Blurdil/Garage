using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class ParkingFormViewModel
    {
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
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