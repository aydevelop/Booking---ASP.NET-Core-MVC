using Booking.DAL.Enums;
using System.Collections.Generic;

namespace Booking.DAL.Models
{
    public class Location : BaseModel
    {
        public string Name { get; set; }
        public LocationState State { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
