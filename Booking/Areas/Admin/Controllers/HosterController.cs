using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HosterController : BaseController<Hoster>
    {
        private readonly IHosterRepository _db;

        public HosterController(IHosterRepository db) : base(db)
        {
            _db = db;
        }
    }
}
