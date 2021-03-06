using Booking.DAL.Models;
using FluentValidation;

namespace Booking.BLL.Validators
{
    public class HosterValidator : AbstractValidator<Hoster>
    {
        public HosterValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(p => p.LastName).NotEmpty().MaximumLength(50);
        }
    }
}
