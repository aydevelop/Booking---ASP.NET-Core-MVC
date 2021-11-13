namespace Booking.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public int AppartementId { get; set; }
        public string Name { get; set; }
        public FeatureState State { get; set; }
    }

    public enum FeatureState
    {
        Draft, Active, Inactive
    }
}
