using Microsoft.AspNetCore.Identity;

namespace Booking.DAL.Models
{
    public class User : IdentityUser
    {
        public int YearOfBirth { get; set; }
    }
}
