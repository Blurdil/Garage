using Garage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberView
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ParkingMinuts { get; set; }
        public int ParkingLot { get; set; }
        public string RegNr { get; set; }

        public string FullName { get; set; }
        
        
        public MemberViewModel toViewModel(Member member)
        {
            MemberViewModel model = new MemberViewModel
            {
                Id = member.Id,
                FullName = member.FirstName + " " + member.LastName,
                Email = member.Email,
                ParkingMinuts =new  CounterService().ConvertToTime(member.ParkingMinuts),
            };
            if (member.Parking.Count != 0)
            {
                model.ParkingLot = member.Parking.Where(x => x.MemberId == member.Id).FirstOrDefault().ParkingLot;
                model.RegNr = member.Parking.Where(x => x.MemberId == member.Id).FirstOrDefault().Vehicle.RegNr;
            }
            return model;
        }   
    }
}