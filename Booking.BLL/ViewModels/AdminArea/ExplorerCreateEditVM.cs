using Booking.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.BLL.ViewModels.AdminArea
{
    public class ExplorerCreateEditVM
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public ExplorerState State { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateFromState { get; set; }
    }
}
