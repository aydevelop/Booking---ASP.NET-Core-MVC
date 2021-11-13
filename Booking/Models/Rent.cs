using System;

namespace Booking.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int AppartementId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RentState State { get; set; }
    }

    public enum RentState
    {
        Requested, Approved, Rejected, Inactive
    }
}
