using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Controllers
{
    public class LocationController : BaseController<Location>
    {
        private readonly ILocationRepository _db;

        public LocationController(ILocationRepository db) : base(db)
        {
            _db = db;
        }
    }
}
