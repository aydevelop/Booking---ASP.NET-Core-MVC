using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(AppDbContext db) : base(db)
        { }
    }
}
