using Booking.DAL.Models;
using System;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels.ExplorerArea
{
    public class RentIndexVM
    {
        public List<Rent> rents { get; set; } = new List<Rent>();
        public Guid? rentId { get; set; }
        public Rent? rent { get; set; }
        public bool? deactivate { get; set; }
    }
}
