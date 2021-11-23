namespace Booking.DAL.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationState State { get; set; }
    }

    public enum LocationState
    {
        Active, Inactive
    }
}
