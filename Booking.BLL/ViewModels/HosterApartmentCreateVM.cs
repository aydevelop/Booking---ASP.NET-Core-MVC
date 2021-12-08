using Booking.BLL.ViewModels.Data;
using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels
{
    public class HosterApartmentCreateVM
    {
        public Apartment apartment { get; set; }
        public List<Hoster> Hosters { get; set; }
        public List<Location> Locations { get; set; }
        public List<Location> Features { get; set; }
        public List<AssignedFeatureData> AssignedFeatures { get; set; }
    }
}
