using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels
{
    public class AdminHomeIndexVM
    {
        public List<Rent> RentsList { get; set; }
        public List<Apartment> ApartmentsList { get; set; }
        public int Hosters { get; set; }
        public int Explorers { get; set; }
        public int Features { get; set; }
        public int Locations { get; set; }
    }
}
