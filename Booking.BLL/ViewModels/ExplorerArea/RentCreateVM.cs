using System;

namespace Booking.BLL.ViewModels.ExplorerArea
{
    public class RentCreateVM
    {
        public Guid ExplorerId { get; set; }
        public Guid ApartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxDurationInDays { get; set; }
    }
}
