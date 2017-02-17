using Garage.Models;
using System;
using System.Data.Entity;

namespace Garage.DAL
{
    public class GarageContextInitialiazer : DropCreateDatabaseAlways<GarageContext>
    {
        protected override void Seed(GarageContext context)
        {
            //var parkingHouses = new[]
            //{
            //    new ParkingHouse { PricePerHour = 60 }
            //};
            //context.ParkingHouse.AddRange(parkingHouses);
            //context.SaveChanges();

            //var parkingHouseFloors = new[]
            //{
            //    new ParkingHouseFloors { Floor = 1, ParkingLots = 40, ParkingHouseId = parkingHouses[0].Id },
            //    new ParkingHouseFloors { Floor = 2, ParkingLots = 43, ParkingHouseId = parkingHouses[0].Id }
            //};
            //context.ParkingHouseFloors.AddRange(parkingHouseFloors);
            //context.SaveChanges();

            var members = new[]
            {
                new Member { FirstName = "Mimer", LastName = "Eklund", Email = "mimer.eklund@gmail.com"},
                new Member { FirstName = "Bert", LastName = "Bertilsson", Email = "bert@gmail.com" },
                new Member { FirstName = "Adam", LastName = "Adamsson", Email = "adam@gmail.com" }
            };
            context.Members.AddRange(members);
            context.SaveChanges();

            var vehicleTypes = new[]
            {
                new VehicleType { Type = "Bil", NumberOfTyre = 4 },
                new VehicleType { Type = "Motorcykel", NumberOfTyre = 2 },
                new VehicleType { Type = "Buss", NumberOfTyre = 8 }
            };
            context.VehiclesType.AddRange(vehicleTypes);
            context.SaveChanges();

            var vehicles = new[]
            {
                new Vehicle { RegNr = "AAA 001", Color = "Svart", Fabricate = "Volvo", FabricateModel = "V70", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[0].Id, StartParkingTime = DateTime.Now.AddHours(-4), ParkingLot = 1 },
                new Vehicle { RegNr = "AAA 002", Color = "Svart", Fabricate = "Saab", FabricateModel = "9000", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[0].Id, StartParkingTime = DateTime.Now.AddHours(-2), ParkingLot = 2 },
                new Vehicle { RegNr = "AAA 003", Color = "Gul", Fabricate = "Ford", FabricateModel = "Focus", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[0].Id, StartParkingTime = DateTime.Now.AddHours(-1), ParkingLot = 4 },
                new Vehicle { RegNr = "AAA 004", Color = "Röd", Fabricate = "Volvo", FabricateModel = "XC 90", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[1].Id, StartParkingTime = DateTime.Now.AddHours(-6), ParkingLot = 5 },
                new Vehicle { RegNr = "AAA 005", Color = "Grå", Fabricate = "Ford", FabricateModel = "Mondeo", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[1].Id, StartParkingTime = DateTime.Now.AddHours(-2), ParkingLot = 10 },
                new Vehicle { RegNr = "AAA 006", Color = "Svart", Fabricate = "Volvo", FabricateModel = "Bus", VehicleTypeId = vehicleTypes[2].Id, MemberId = members[0].Id, StartParkingTime = DateTime.Now.AddHours(-10), ParkingLot = 12 },
            };
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();

        }
    }
}