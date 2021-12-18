namespace Booking.BLL.Contracts
{
    public interface IRepositories
    {
        public IApartmentRepository Apartments { get; }
        public IHosterRepository Hosters { get; }
        public ILocationRepository Locations { get; }
        public IExplorerRepository Explorers { get; }
        public IFeatureRepository Features { get; }
        public IRentRepository Rents { get; }
        public IApartmentFeatureRepository ApartmentFeatures { get; }
        public IRateRepository Rates { get; }
        public IComplainRepository Complaints { get; }
    }
}
