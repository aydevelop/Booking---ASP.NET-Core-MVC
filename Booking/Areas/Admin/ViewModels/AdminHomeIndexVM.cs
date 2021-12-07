using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.Areas.Admin.ViewModels
{
    public class AdminHomeIndexVM
    {
        public List<Rent> Rents { get; set; }
        public int Hosters { get; set; }
        public int Explorers { get; set; }
        public int Apartments { get; set; }
        public int Features { get; set; }
        public int Locations { get; set; }
    }
}
