using Booking.BLL.Contracts;
using Booking.BLL.Jobs;
using Booking.DAL;
using Booking.Extensions;
using Booking.Middlewares;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Booking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddDInjection();
            services.AddLibrary();
            services.AddAuth();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRepositories repositories)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ExceptionHandler");
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/HandleError/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHangfireDashboard();
            });

            RecurringJob.AddOrUpdate("UnbanUser", () =>
                new UnbanUserJob(repositories.Explorers).Run(), UnbanUserJob.Interval);

            RecurringJob.AddOrUpdate("DraftApartment", () =>
                 new DraftApartmentJob(repositories).Run(), DraftApartmentJob.Interval);
        }
    }
}
