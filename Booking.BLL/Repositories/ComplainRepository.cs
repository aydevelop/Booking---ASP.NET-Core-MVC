using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class ComplainRepository : BaseRepository<Complaint>, IComplainRepository
    {
        public ComplainRepository(AppDbContext db) : base(db)
        { }
    }
}
