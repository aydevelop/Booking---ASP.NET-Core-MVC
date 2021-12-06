using Booking.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class Apartment : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double AvgScore { get; set; }
        [Display(Name = "MaxDuration")]
        public int MaxDurationInDays { get; set; }
        public ApartmentState State { get; set; }

        [Display(Name = "Hoster")]
        public int HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
