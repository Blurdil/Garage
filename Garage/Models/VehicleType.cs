using System.Collections;
using System.Collections.Generic;

namespace Garage.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfTyre { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}