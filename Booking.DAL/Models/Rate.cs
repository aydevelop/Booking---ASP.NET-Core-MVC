using System;

namespace Booking.DAL.Models
{
    public class Rate : BaseModel
    {
        public int Value { get; set; }

        public Guid? RentId { get; set; }
        public Rent Rent { get; set; }

        public Guid? ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
