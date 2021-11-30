using Booking.DAL.Enums;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Booking.DAL.Models
{
    public class Apartment : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double AvgScore { get; set; }
        [Display(Name = "MaxDuration (Days)")]
        public int MaxDurationInDays { get; set; }
        public ApartmentState State { get; set; }

        [Display(Name = "Hoster")]
        public int HosterId { get; set; }
        public virtual Hoster Hoster { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        private readonly AppDbContext _db;
        private Apartment _model;

        public ApartmentValidator(AppDbContext db)
        {
            _db = db;

            RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
            RuleFor(p => p.Name).Must((item) => IsDuplicate(item)).WithMessage("Apartment already exists");
        }

        protected override bool PreValidate(ValidationContext<Apartment> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }

        private bool IsDuplicate(string name)
        {
            if (_model?.Id > 0) { return true; }

            var location = _db.Apartments.FirstOrDefault(q => q.Name == name);
            if (location == null)
            {
                return true;
            }

            return false;
        }
    }
}
