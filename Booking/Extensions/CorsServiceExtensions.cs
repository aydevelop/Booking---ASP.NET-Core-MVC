using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Extensions
{
    public static class CorsServiceExtensions
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCorsServices(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
