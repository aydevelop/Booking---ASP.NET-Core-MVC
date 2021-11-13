namespace Booking.Models
{
    public class Hoster
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HosterState State { get; set; }
    }

    public enum HosterState
    {
        Draft, Active, Inactive
    }
}
