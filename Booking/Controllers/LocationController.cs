using Booking.DAL;
using Booking.DAL.Models;

namespace Booking.Controllers
{
    public class LocationController : BaseController<Location>
    {
        private readonly AppDbContext _db;

        public LocationController(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
