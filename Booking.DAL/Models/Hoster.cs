using Booking.DAL.Enums;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Models
{
    public class Hoster : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HosterState State { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }

    public class HosterValidator : AbstractValidator<Hoster>
    {
        public HosterValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(p => p.LastName).NotEmpty().MaximumLength(100);
        }
    }
}
