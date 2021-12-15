using System;

namespace Booking.DAL.Models
{
    public class ApartmentFeature : BaseModel
    {
        public Guid ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        public Guid FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
