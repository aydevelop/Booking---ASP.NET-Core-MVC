namespace Booking.DAL.Models
{
    public class ApartmentFeature : BaseModel
    {
        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        public int FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
