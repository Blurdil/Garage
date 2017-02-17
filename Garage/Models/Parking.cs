using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public int ParkingLot { get; set; }
        public DateTime StartParkingTime { get; set; }

        
        public int MemberId { get; set; }
       
        public int VehicleId { get; set; }
        
       // public int ParkingHouseId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        //public virtual ParkingHouse ParkingHouse { get; set; }
    }
}