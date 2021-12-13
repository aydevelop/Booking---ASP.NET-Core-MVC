using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    public class RentController : Controller
    {
        private readonly IRepositories _db;

        public RentController(IRepositories db)
        {
            _db = db;
        }

        public async Task<ActionResult> Approve(int id)
        {
            var rent = await _db.Rents.GetById(id);
            if (rent == null) { return NotFound(); }

            rent.State = RentState.Approved;
            await _db.Rents.Update(rent);

            return RedirectToAction(nameof(Approved));
        }

        public async Task<ActionResult> Reject(int id)
        {
            var rent = await _db.Rents.GetById(id);
            if (rent == null) { return NotFound(); }

            rent.State = RentState.Rejected;
            await _db.Rents.Update(rent);

            return RedirectToAction(nameof(Rejected));
        }

        public async Task<ActionResult> Requested()
        {
            var rents = await _db.Rents.GetByFiler(q => q.State == RentState.Requested);
            return View(rents);
        }

        public async Task<ActionResult> Approved()
        {
            var rents = await _db.Rents.GetByFiler(q => q.State == RentState.Approved);
            return View(rents);
        }

        public async Task<ActionResult> Rejected()
        {
            var rents = await _db.Rents.GetByFiler(q => q.State == RentState.Rejected);
            return View(rents);
        }

        public async Task<ActionResult> Inactive()
        {
            var rents = await _db.Rents.GetByFiler(q => q.State == RentState.Inactive);
            return View(rents);
        }
    }
}
