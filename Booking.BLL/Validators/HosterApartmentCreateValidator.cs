using Booking.BLL.ViewModels;
using Booking.DAL;
using FluentValidation;
using System.Linq;

namespace Booking.BLL.Validators
{
    public class HosterApartmentCreateValidator : AbstractValidator<ApartmentCreateVM>
    {
        private readonly AppDbContext _db;
        private ApartmentCreateVM _model;

        public HosterApartmentCreateValidator(AppDbContext db)
        {
            _db = db;

            RuleFor(p => p.apartment.Name).NotEmpty().MaximumLength(100);
            RuleFor(p => p.apartment.Name).Must((item) => IsNotDuplicate(item)).WithMessage("Apartment already exists");
            RuleFor(p => p.apartment.Address).NotEmpty().MaximumLength(200);
        }

        protected override bool PreValidate(ValidationContext<ApartmentCreateVM> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }

        private bool IsNotDuplicate(string name)
        {
            var query = _db.Apartments.AsQueryable();
            if (_model.apartment?.Id != null)
            {
                query = query.Where(q => q.Id != _model.apartment.Id);
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
