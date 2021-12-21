using Booking.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class Apartment : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double AvgScore { get; set; }
        [Display(Name = "MaxDuration")]
        public int MaxDurationInDays { get; set; } = 1;
        public ApartmentState State { get; set; }

        [Display(Name = "Hoster")]
        public Guid HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        [Display(Name = "Location")]
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual List<ApartmentFeature> Features { get; set; } = new List<ApartmentFeature>();
        public virtual List<Rate> Rates { get; set; } = new List<Rate>();
    }
}
