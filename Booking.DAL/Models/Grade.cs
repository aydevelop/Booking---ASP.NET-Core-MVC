using System;

namespace Booking.DAL.Models
{
    public class Grade : BaseModel
    {
        public Guid ApartementId { get; set; }
        public Guid ExplorerId { get; set; }
        public double Score { get; set; }
    }
}
