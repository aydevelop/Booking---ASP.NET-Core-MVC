using Booking.DAL.Enums;
using System;

namespace Booking.DAL.Models
{
    public class Rent : BaseModel
    {
        public int ExplorerId { get; set; }
        public int AppartementId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RentState State { get; set; }
    }
}
