using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Controllers
{
    public class HosterController : BaseController<Hoster>
    {
        private readonly IHosterRepository _db;

        public HosterController(IHosterRepository db) : base(db)
        {
            _db = db;
        }
    }
}
