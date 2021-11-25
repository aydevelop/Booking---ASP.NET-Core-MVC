using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.ViewModels
{
    public class ApartmentCreditVM : Apartment
    {
        public List<Hoster> Hosters { get; set; }
        public List<Location> Locations { get; set; }
    }
}
