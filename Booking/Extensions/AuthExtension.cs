using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Extensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services
              .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = "/account/login";
              });

            services
               .AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
