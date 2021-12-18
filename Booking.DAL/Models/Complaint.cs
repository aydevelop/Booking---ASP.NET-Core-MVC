using System;

namespace Booking.DAL.Models
{
    public class Complaint : BaseModel
    {
        public string Text { get; set; }

        public Guid HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        public Guid ExplorerId { get; set; }
        public virtual Explorer Explorer { get; set; }
    }
}
