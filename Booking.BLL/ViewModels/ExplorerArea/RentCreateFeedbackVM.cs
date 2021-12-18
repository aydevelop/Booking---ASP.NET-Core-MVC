using System;

namespace Booking.BLL.ViewModels.ExplorerArea
{
    public class RentCreateFeedbackVM
    {
        public Guid RentId { get; set; }
        public Guid ApartmentId { get; set; }
        public int Rate { get; set; }
    }
}
