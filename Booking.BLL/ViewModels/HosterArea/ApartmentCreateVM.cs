using Booking.BLL.ViewModels.Data;
using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels
{
    public class ApartmentCreateVM
    {
        public Apartment apartment { get; set; }
        public List<Hoster> Hosters { get; set; } = new List<Hoster>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Location> Features { get; set; } = new List<Location>();
        public List<AssignedFeatureData> AssignedFeatures { get; set; } = new List<AssignedFeatureData>();
    }
}
