using Booking.BLL.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Extensions
{
    public static class LibraryExtension
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApartmentValidator>());

            return services;
        }
    }
}
