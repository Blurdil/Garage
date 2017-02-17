using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberViews
{
    public class MemberCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Member toEntity(MemberCreateViewModel model)
        {
            Member member = new Member
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };
            return member;
        }
    }
}