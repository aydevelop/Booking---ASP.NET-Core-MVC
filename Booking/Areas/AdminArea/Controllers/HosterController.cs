using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Areas.Admin.Controllers
{
    public class HosterController : AdminAreaController<Hoster>
    {
        private readonly IHosterRepository _db;

        public HosterController(IHosterRepository db) : base(db)
        {
            _db = db;
        }
    }
}
