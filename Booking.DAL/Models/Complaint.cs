using System;

namespace Booking.DAL.Models
{
    public class Complaint : BaseModel
    {
        public string Text { get; set; }

        public string HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        public string ExplorerId { get; set; }
        public virtual Explorer Explorer { get; set; }

        public Guid? RentId { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
