using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garage.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
        public int ParkingLot { get; set; }
        public DateTime StartParkingTime { get; set; }

        public int  VehicleTypeId { get; set;}
        public int MemberId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Member Member { get; set;}

    }
}