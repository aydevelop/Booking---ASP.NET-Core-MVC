using System;

namespace Booking.BLL.ViewModels.Data
{
    public class AssignedFeatureData
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Assigned { get; set; }
    }
}
