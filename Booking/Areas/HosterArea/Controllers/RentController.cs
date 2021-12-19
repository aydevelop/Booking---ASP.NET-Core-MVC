using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public virtual async Task<ActionResult> Details(Guid? id)
        {
            if (id == null) { return BadRequest(); }

            var item = await _db.Rents.GetByFilerWithInclude(q => q.Id == id.Value,
                new[] { "Explorer", "Apartment", "Complaint" });
            if (item.Count == 0) { return NotFound(); }

            return View(item.First());
        }


        public async Task<ActionResult> Approve(Guid id)
        {
            var rent = await _db.Rents.GetById(id);
            if (rent == null) { return NotFound(); }

            rent.State = RentState.Approved;
            await _db.Rents.Update(rent);

            return RedirectToAction(nameof(Approved));
        }

        public async Task<ActionResult> Reject(Guid id)
        {
            var rent = await _db.Rents.GetById(id);
            if (rent == null) { return NotFound(); }

            rent.State = RentState.Rejected;
            await _db.Rents.Update(rent);

            return RedirectToAction(nameof(Rejected));
        }

        public async Task<ActionResult> Requested()
        {
            var rents = await _db.Rents
                .GetByFilerWithInclude(q => q.State == RentState.Requested,
                new[] { "Explorer", "Apartment" });

            return View(rents);
        }

        public async Task<ActionResult> Approved()
        {
            var rents = await _db.Rents
               .GetByFilerWithInclude(q => q.State == RentState.Approved,
               new[] { "Explorer", "Apartment" });

            return View(rents);
        }

        public async Task<ActionResult> Rejected()
        {
            var rents = await _db.Rents
               .GetByFilerWithInclude(q => q.State == RentState.Rejected,
               new[] { "Explorer", "Apartment" });

            return View(rents);
        }

        public async Task<ActionResult> Inactive()
        {
            var rents = await _db.Rents
               .GetByFilerWithInclude(q => q.State == RentState.Inactive,
               new[] { "Explorer", "Apartment" });

            return View(rents);
        }
    }
}
