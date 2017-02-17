using Garage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class ReciptViewModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Duration { get; set; }
        public int Cost { get; set; }
        public string RegNr { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
        public string MemberName { get; set; }

        public ReciptViewModel toViewModel(Parking parking)
        {
            DateTime endTime = DateTime.Now;
            CounterService cs = new CounterService();
            var minuts = cs.ConvertToMinuts(parking.StartParkingTime, endTime);
            string duration = cs.ConvertToTime(minuts);
            int cost = cs.GetCost(minuts); 
            ReciptViewModel model = new ReciptViewModel
            {
                StartTime = parking.StartParkingTime,
                EndTime = endTime,
                RegNr = parking.Vehicle.RegNr,
                Fabricate = parking.Vehicle.Fabricate,
                FabricateModel = parking.Vehicle.FabricateModel,
                MemberName = parking.Member.FirstName + " " + parking.Member.LastName,
                Duration = duration,
                Cost = cost,
            };
            return model;
        }
    }
}