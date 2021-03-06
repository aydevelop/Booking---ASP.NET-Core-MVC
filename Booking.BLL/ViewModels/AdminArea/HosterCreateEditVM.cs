using Booking.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.BLL.ViewModels.AdminArea
{
    public class HosterCreateEditVM
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public HosterState State { get; set; }
    }
}
