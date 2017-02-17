using Garage.DAL;
using Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Service
{
    public class ParkingService
    {
        private GarageContext db = new GarageContext();
        private int parkinglots = 6;
        public int pricePerHour = 45;
        
        public int FirstFreeParking(List<Vehicle> vehicles)
        {
            List<int> occipiedLots = new List<int>();
            int firstFree = 0;
            foreach (var parking in vehicles)
            {
                if (!occipiedLots.Contains(parking.ParkingLot))
                    occipiedLots.Add(parking.ParkingLot);
            }
            for(var i = 1; i < parkinglots; i ++)
            {
                if (!occipiedLots.Contains(i))
                {
                    firstFree = i;
                    break;
                }
            }
            return firstFree;
        }

        public int FreeLots()
        {
            int freeLots = parkinglots - db.Vehicles.Count();
            return freeLots;
        }
    }
}