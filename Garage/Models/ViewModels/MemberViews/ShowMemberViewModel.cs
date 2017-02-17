using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberViews
{
    public class ShowMemberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "E-Post")]
        public string Email { get; set; }
        [Display(Name = "Antal Parkerade Fordon")]
        public int ParkedVehicles { get; set; }
        public List<ShowMemberViewModel> Members { get; set; }

        public ShowMemberViewModel toViewModel(List<Member> members)
        {
            ShowMemberViewModel model = new ShowMemberViewModel();
            model.Members = new List<ShowMemberViewModel>();
            foreach(var member in members)
            {
                ShowMemberViewModel m = new ShowMemberViewModel
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    ParkedVehicles = member.Vehicles.Count(),
                };
                model.Members.Add(m);
            }
            return model;
        }
    }
}