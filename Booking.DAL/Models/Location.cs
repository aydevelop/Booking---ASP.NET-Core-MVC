using Booking.DAL.Enums;

namespace Booking.DAL.Models
{
    public class Location : BaseModel
    {
        public string Name { get; set; }
        public LocationState State { get; set; }
    }
}
