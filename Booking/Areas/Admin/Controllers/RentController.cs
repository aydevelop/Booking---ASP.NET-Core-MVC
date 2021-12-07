using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentController : BaseController<Rent>
    {
        private readonly IRentRepository _dbRent;

        public RentController(IRentRepository dbRent) : base(dbRent)
        {
            _dbRent = dbRent;
        }

        public override async Task<ActionResult> Index()
        {
            var items = await _dbRent.GetWithInclude(new string[] { "Explorer", "Apartment" });
            return View(items);
        }
    }
}
