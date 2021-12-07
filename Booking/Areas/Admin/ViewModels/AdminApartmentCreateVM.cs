using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.Areas.Admin.ViewModels
{
    public class AdminApartmentCreateVM
    {
        Apartment apartment { get; set; }
        List<Hoster> Hosters { get; set; }
        List<Location> Locations { get; set; }
        List<Feature> Features { get; set; }
    }
}
