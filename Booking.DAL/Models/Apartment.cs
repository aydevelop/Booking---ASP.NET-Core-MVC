using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class Apartment : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double AvgScore { get; set; }
        [Required]
        public int MaxDurationInDays { get; set; }
        [Required]
        public ApartmentState State { get; set; }

        [Required]
        [Display(Name = "Hoster")]
        public int HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public enum ApartmentState
    {
        Draft, Active, Inactive
    }
}
