using Garage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage.DAL
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base("GarageContext")
        {
            Database.SetInitializer(new GarageContextInitialiazer());

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        //public DbSet<ParkingHouse> ParkingHouse { get; set; }
        //public DbSet<ParkingHouseFloors> ParkingHouseFloors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehiclesType { get; set; }
    }
}