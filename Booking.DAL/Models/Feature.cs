using Booking.DAL.Enums;
using System.Collections.Generic;

namespace Booking.DAL.Models
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public FeatureState State { get; set; }

        public virtual List<ApartmentFeature> Apartments { get; set; } = new List<ApartmentFeature>();
    }
}
