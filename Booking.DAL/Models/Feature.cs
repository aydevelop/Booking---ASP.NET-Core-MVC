namespace Booking.DAL.Models
{
    public class Feature : BaseModel
    {
        public int AppartementId { get; set; }
        public string Name { get; set; }
        public FeatureState State { get; set; }
    }

    public enum FeatureState
    {
        Draft, Active, Inactive
    }
}
