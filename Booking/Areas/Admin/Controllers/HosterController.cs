using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HosterController : BaseController<Hoster>
    {
        private readonly IHosterRepository _db;

        public HosterController(IHosterRepository db) : base(db)
        {
            _db = db;
        }
    }
}
