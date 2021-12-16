using Booking.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class Rent : BaseModel
    {
        public RentState State { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Guid ExplorerId { get; set; }
        public virtual Explorer Explorer { get; set; }

        public Guid ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
