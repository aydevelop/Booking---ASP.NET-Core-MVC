using Booking.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Models
{
    public class Explorer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public ExplorerState State { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateFromState { get; set; }

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
