using Booking.BLL.Contracts;
using Booking.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Extensions
{
    public static class DInjectionExtension
    {
        public static IServiceCollection AddDInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IRepositories, Repositories>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IHosterRepository, HosterRepository>();
            services.AddScoped<IExplorerRepository, ExplorerRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IApartmentFeatureRepository, ApartmentFeatureRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IComplainRepository, ComplainRepository>();

            return services;
        }
    }
}
