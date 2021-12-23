using Booking.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Models
{
    public class Hoster : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HosterState State { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return (FirstName ?? "-") + " " + (LastName ?? "-");
            }
        }
    }
}
