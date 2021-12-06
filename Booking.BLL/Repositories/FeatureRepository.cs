using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext db) : base(db)
        { }
    }
}
