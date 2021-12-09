using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class ApartmentFeatureRepository : BaseRepository<ApartmentFeature>, IApartmentFeatureRepository
    {
        public ApartmentFeatureRepository(AppDbContext db) : base(db)
        {
        }
    }
}
