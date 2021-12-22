using Booking.BLL.Validators;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Booking.Extensions
{
    public static class LibraryExtension
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var conf = provider.GetRequiredService<IConfiguration>();
            var env = provider.GetRequiredService<IWebHostEnvironment>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LocationValidator>());

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(conf.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));
            services.AddHangfireServer();


            return services;
        }

        public static IApplicationBuilder AddLibrary(this IApplicationBuilder app)
        {
            //app.UseHangfireDashboard();
            return app;
        }
    }
}
