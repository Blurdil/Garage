using Garage.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.ParkingViews
{
    public class ReciptViewModel
    {
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd HH:mm}")]
        [Display(Name = "Parkering Startad")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd HH:mm}")]
        [Display(Name = "Parkering Avslutad")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Parkerad Tid")]
        public string Duration { get; set; }
        [Display(Name = "Kostnad")]
        public double Cost { get; set; }
        [Display(Name = "Registrerings Nummer")]
        public string RegNr { get; set; }
        [Display(Name = "Märke")]
        public string Fabricate { get; set; }
        [Display(Name = "Model")]
        public string FabricateModel { get; set; }
        [Display(Name = "Medlem")]
        public string MemberName { get; set; }

        public ReciptViewModel toViewModel(Vehicle vehicle)
        {
            DateTime endTime = DateTime.Now;
            CounterService cs = new CounterService();
            double minuts = cs.ConvertToMinuts(vehicle.StartParkingTime, endTime);
            string duration = cs.ConvertToTime(minuts);
            double cost = cs.GetCost(minuts); 
            ReciptViewModel model = new ReciptViewModel
            {
                StartTime = vehicle.StartParkingTime,
                EndTime = endTime,
                RegNr = vehicle.RegNr,
                Fabricate = vehicle.Fabricate,
                FabricateModel = vehicle.FabricateModel,
                MemberName = vehicle.Member.FirstName + " " + vehicle.Member.LastName,
                Duration = duration,
                Cost = cost,
            };
            return model;
        }
    }
}