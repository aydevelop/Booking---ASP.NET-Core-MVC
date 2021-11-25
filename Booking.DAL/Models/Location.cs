using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class Location : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public LocationState State { get; set; }
    }

    public enum LocationState
    {
        Active, Inactive
    }
}
