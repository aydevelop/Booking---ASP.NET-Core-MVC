using Booking.DAL.Enums;

namespace Booking.DAL.Models
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public FeatureState State { get; set; }
    }
}
