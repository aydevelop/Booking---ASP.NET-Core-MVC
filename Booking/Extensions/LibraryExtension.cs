using Booking.BLL.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Extensions
{
    public static class LibraryExtension
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LocationValidator>());

            return services;
        }

        public static IApplicationBuilder AddLibrary(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
