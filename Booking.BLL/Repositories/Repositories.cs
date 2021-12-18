using Booking.BLL.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Booking.BLL.Repositories
{
    public class Repositories : IRepositories
    {
        private readonly IServiceProvider _services;
        private IRentRepository _rent;
        private IFeatureRepository _feature;
        private IExplorerRepository _explorer;
        private ILocationRepository _location;
        private IHosterRepository _hoster;
        private IApartmentRepository _apartment;
        private IApartmentFeatureRepository _apartmentFeature;
        private IRateRepository _rate;
        private IComplainRepository _complaint;

        public Repositories(IServiceProvider services)
        {
            _services = services;
        }

        public IApartmentRepository Apartments => _apartment ??= _services.GetRequiredService<IApartmentRepository>();

        public IHosterRepository Hosters => _hoster ??= _services.GetRequiredService<IHosterRepository>();

        public ILocationRepository Locations => _location ??= _services.GetRequiredService<ILocationRepository>();

        public IExplorerRepository Explorers => _explorer ??= _services.GetRequiredService<IExplorerRepository>();

        public IFeatureRepository Features => _feature ??= _services.GetRequiredService<IFeatureRepository>();

        public IRentRepository Rents => _rent ??= _services.GetRequiredService<IRentRepository>();

        public IApartmentFeatureRepository ApartmentFeatures => _apartmentFeature ??= _services.GetRequiredService<IApartmentFeatureRepository>();

        public IRateRepository Rates => _rate ??= _services.GetRequiredService<IRateRepository>();

        public IComplainRepository Complaints => _complaint ??= _services.GetRequiredService<IComplainRepository>();
    }
}
