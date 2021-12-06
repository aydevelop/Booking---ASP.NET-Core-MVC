using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentController : BaseController<Rent>
    {
        private readonly IRentRepository _db;

        public RentController(IRentRepository db) : base(db)
        {
            _db = db;
        }
    }
}
