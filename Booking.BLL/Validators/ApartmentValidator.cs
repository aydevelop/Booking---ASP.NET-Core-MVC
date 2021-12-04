using Booking.DAL;
using Booking.DAL.Models;
using FluentValidation;
using System.Linq;

namespace Booking.BLL.Validators
{
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
