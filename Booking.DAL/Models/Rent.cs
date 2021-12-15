using Booking.DAL.Enums;
using System;

namespace Booking.DAL.Models
{
    public class Rent : BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RentState State { get; set; }

        public Guid ExplorerId { get; set; }
        public virtual Explorer Explorer { get; set; }

        public Guid ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
