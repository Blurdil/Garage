using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage.Models.ViewModels.MemberViews
{
    public class MemberCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Måste ange ett förnamn")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Måste ange ett efternamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "E-post")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Måste vara i E-post format( asd@gmail.com )")]
        public string Email { get; set; }

        public MemberCreateViewModel ToViewModel(Member member)
        {
            MemberCreateViewModel model = new MemberCreateViewModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
            };
            return model;
        }

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