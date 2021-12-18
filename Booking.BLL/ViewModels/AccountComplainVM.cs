using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.BLL.ViewModels
{
    public class AccountComplainVM
    {
        [Required(ErrorMessage = "RentId is required")]
        public Guid RentId { get; set; }
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Text is required")]
        [StringLength(200, ErrorMessage = "Text length can't be more than 8.")]
        public string Text { get; set; }
    }
}
