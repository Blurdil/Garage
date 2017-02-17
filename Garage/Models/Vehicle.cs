using System.Collections;
using System.Collections.Generic;

namespace Garage.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }

        public int  VehicleTypeId { get; set;}
        public int ParkingId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Parking> Parking { get; set; }
    }
}