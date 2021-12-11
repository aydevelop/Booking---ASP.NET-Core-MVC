using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Areas.Admin.Controllers
{
    public class LocationController : AdminAreaController<Location>
    {
        private readonly ILocationRepository _db;

        public LocationController(ILocationRepository db) : base(db)
        {
            _db = db;
        }
    }
}
