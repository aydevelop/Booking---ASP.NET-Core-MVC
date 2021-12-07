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
    }
}
