using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels.HosterArea
{
    public class ApartmentIndexVM
    {
        public List<Apartment> apartments { get; set; } = new List<Apartment>();
        public List<Rent> rents { get; set; } = new List<Rent>();
    }
}
