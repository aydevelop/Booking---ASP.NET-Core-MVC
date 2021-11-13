using System;

namespace Booking.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HosterId { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public double AvgScore { get; set; }
        public TimeSpan MaxDuration { get; set; }
        public ApartmentState State { get; set; }
    }

    public enum ApartmentState
    {
        Draft, Active, Inactive
    }
}
