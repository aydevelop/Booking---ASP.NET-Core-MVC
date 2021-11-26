using Booking.DAL.Enums;
using System;

namespace Booking.DAL.Models
{
    public class Explorer : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ExplorerState State { get; set; }
        public ExplorerState StateFromDate { get; set; }
    }


}
