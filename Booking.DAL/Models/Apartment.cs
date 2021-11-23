namespace Booking.DAL.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double AvgScore { get; set; }
        public int MaxDurationInDays { get; set; }
        public ApartmentState State { get; set; }

        public int HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public enum ApartmentState
    {
        Draft, Active, Inactive
    }
}
