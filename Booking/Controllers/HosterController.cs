using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.Controllers
{
    public class HosterController : BaseController<Hoster>
    {
        private readonly AppDbContext _db;

        public HosterController(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
