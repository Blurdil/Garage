using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ParkingMinuts { get; set; }
        public int ParkingId { get; set; }

        public virtual ICollection<Parking> Parking { get; set; }
    }
}