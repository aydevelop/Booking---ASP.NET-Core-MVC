using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        public RateRepository(AppDbContext db) : base(db)
        { }
    }
}
