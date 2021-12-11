using Booking.DAL.Models;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels.HosterArea
{
    public class ApartmentDetailsVM
    {
        public Apartment apartment { get; set; } = new Apartment();
        public List<Rent> rents { get; set; } = new List<Rent>();
    }
}
