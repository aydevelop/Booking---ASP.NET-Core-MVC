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
            RuleFor(p => p.Name).Must((item) => IsNotDuplicate(item)).WithMessage("Apartment already exists");
            RuleFor(p => p.Address).NotEmpty().MaximumLength(200);
        }

        protected override bool PreValidate(ValidationContext<Apartment> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }

        private bool IsNotDuplicate(string name)
        {
            var query = _db.Apartments.AsQueryable();
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
