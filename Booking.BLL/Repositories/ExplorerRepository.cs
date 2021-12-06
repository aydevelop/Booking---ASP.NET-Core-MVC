using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.BLL.Repositories
{
    public class ExplorerRepository : BaseRepository<Explorer>, IExplorerRepository
    {
        public ExplorerRepository(AppDbContext db) : base(db)
        { }
    }
}