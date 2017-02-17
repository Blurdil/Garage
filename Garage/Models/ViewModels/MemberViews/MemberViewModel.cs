using Garage.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberView
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "E-Post")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Registrerings Nummer")]
        public string RegNr { get; set; }
        [Display(Name = "Lediga Platser")]
        public int FreeLots { get; set; }
        [Display(Name = "Fordon")]
        public ICollection<Vehicle> vehicles { get; set; }

        [Display(Name = "Namn")]
        public string FullName { get; set; }
        
        
        public MemberViewModel toViewModel(Member member)
        {
            MemberViewModel model = new MemberViewModel
            {
                Id = member.Id,
                FullName = member.FirstName + " " + member.LastName,
                Email = member.Email,
                vehicles = member.Vehicles.OrderBy(x => x.ParkingLot).ToList(),
                FreeLots = new ParkingService().FreeLots(),
            };
            return model;
        }   
    }
}