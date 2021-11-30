using Booking.DAL.Enums;
using FluentValidation;
using System.Linq;

namespace Booking.DAL.Models
{
    public class Location : BaseModel
    {
        public string Name { get; set; }
        public LocationState State { get; set; }
    }

    public class LocationValidator : AbstractValidator<Location>
    {
        private readonly AppDbContext _db;
        private Location _model;

        public LocationValidator(AppDbContext db)
        {
            _db = db;
            RuleFor(p => p.Name).NotEmpty().MaximumLength(200);
            RuleFor(p => p.Name).Must((item) => IsDuplicate(item)).WithMessage("Location already exists");
        }

        protected override bool PreValidate(ValidationContext<Location> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }

        private bool IsDuplicate(string name)
        {
            if (_model?.Id > 0) { return true; }

            var location = _db.Locations.FirstOrDefault(q => q.Name == name);
            if (location == null)
            {
                return true;
            }

            return false;
        }

    }
}
