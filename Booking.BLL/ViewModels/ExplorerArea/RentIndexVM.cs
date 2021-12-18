using Booking.DAL.Models;
using System;
using System.Collections.Generic;

namespace Booking.BLL.ViewModels.ExplorerArea
{
    public class RentIndexVM
    {
        public List<Rent> Rents { get; set; } = new List<Rent>();
        public Guid? RentId { get; set; }
        public Rent Rent { get; set; }
        public bool? Deactivate { get; set; }
    }
}
