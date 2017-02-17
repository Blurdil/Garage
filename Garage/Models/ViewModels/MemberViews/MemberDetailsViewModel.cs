using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberViews
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "E-Post")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Antal parkerade bilar")]
        public int ParkedVehicles { get; set; }
        public IList<Vehicle> Vehicles { get; set; }

        public  MemberDetailsViewModel ToViewModel(Member member)
        {
            MemberDetailsViewModel model = new MemberDetailsViewModel
            {
                Id = member.Id,
                Name = member.FirstName + " " + member.LastName,
                Email = member.Email,
                ParkedVehicles = member.Vehicles.Count(),
                Vehicles =  member.Vehicles.ToList(),
            };
            return model;
        }
    }
}