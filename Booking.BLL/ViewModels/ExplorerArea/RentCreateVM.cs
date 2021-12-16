using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.BLL.ViewModels.ExplorerArea
{
    public class RentCreateVM
    {
        public Guid ExplorerId { get; set; }
        public Guid ApartmentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int MaxDurationInDays { get; set; }
    }
}
