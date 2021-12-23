using Booking.BLL.ViewModels.ExplorerArea;
using FluentValidation;
using System;

namespace Booking.BLL.Validators
{
    public class ExplorerRentCreateValidator : AbstractValidator<RentCreateVM>
    {
        private RentCreateVM _model;

        public ExplorerRentCreateValidator()
        {
            RuleFor(s => s.StartDate).Must((item) => IsValidStartDate(item)).WithMessage("Invalid StartDate");
            RuleFor(s => s.EndDate).Must((item) => IsValidEndDate(item)).WithMessage("Invalid StartDate");
        }

        private bool IsValidStartDate(DateTime value)
        {
            DateTime now = DateTime.Now;
            if (value < now || value > _model.EndDate)
            {
                return false;
            }

            return true;
        }

        private bool IsValidEndDate(DateTime value)
        {
            DateTime start = _model.StartDate;
            DateTime limit = start.AddDays(_model.MaxDurationInDays);

            if (value > limit)
            {
                return false;
            }

            return true;
        }

        protected override bool PreValidate(ValidationContext<RentCreateVM> context, FluentValidation.Results.ValidationResult result)
        {
            _model = context.InstanceToValidate;
            return base.PreValidate(context, result);
        }
    }
}
