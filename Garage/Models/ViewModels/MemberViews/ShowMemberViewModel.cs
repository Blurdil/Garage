using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberViews
{
    public class ShowMemberViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
                    ParkedVehicles = member.Parking.Count(),
                };
                model.Members.Add(m);
            }
            return model;
        }
    }
}