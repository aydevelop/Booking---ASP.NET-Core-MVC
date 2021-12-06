using Booking.DAL;
using Booking.DAL.Models;
using FluentValidation;
using System.Linq;

namespace Booking.BLL.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        private readonly AppDbContext _db;
        private Location _model;

        public LocationValidator(AppDbContext db)
        {
            _db = db;

            RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
            RuleFor(p => p.Name).Must((item) => IsNotDuplicate(item)).WithMessage("Location already exists");
        }

        protected override bool PreValidate(ValidationContext<Location> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }

        private bool IsNotDuplicate(string name)
        {
            var query = _db.Locations.AsQueryable();
            if (_model?.Id > 0)
            {
                query = query.Where(q => q.Id != _model.Id);
            }

            var location = query.FirstOrDefault(q => q.Name == name);
            if (location == null)
            {
                return true;
            }

            return false;
        }
    }
}
