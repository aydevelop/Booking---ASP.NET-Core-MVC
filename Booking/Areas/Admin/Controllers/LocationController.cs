using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : BaseController<Location>
    {
        private readonly ILocationRepository _db;

        public LocationController(ILocationRepository db) : base(db)
        {
            _db = db;
        }
    }
}
