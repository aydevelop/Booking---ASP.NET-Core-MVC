using System;

namespace Booking.DAL.Models
{
    public class Explorer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ExplorerState State { get; set; }
        public ExplorerState StateFromDate { get; set; }
    }

    public enum ExplorerState
    {
        Requested, Approved, Rejected, Inactive
    }
}
