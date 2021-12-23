using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.ExplorerArea;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Booking.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Areas.ExplorerArea.Controllers
{
    [Authorize]
    [Area("ExplorerArea")]
    [Authorize(Roles = "explorer")]
    public class RentController : Controller
    {
        private readonly IRepositories _db;

        public RentController(IRepositories db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index(RentIndexVM input)
        {
            RentIndexVM model = new RentIndexVM();
            if (input.RentId != null)
            {
                model.RentId = input.RentId;
            }

            if (input.RentId != null)
            {
                var findRent = await _db.Rents.GetByFilerWithInclude(q => q.Id == input.RentId.Value, new[] { "Rate" });
                if (findRent.Count > 0)
                {
                    model.Rent = findRent.First();
                    if (input.Deactivate != null)
                    {
                        model.Rent.State = RentState.Inactive;
                        await _db.Rents.Update(model.Rent);
                    }
                }
            }

            var all = await _db.Explorers.GetAll();
            var userId = User.GetUserId();

            model.Rents = await _db.Rents.GetByFilerWithInclude(
                q => q.ExplorerId == userId,
                new string[] { "Apartment" }
            );

            return View(model);
        }

        public async Task<ActionResult> Create([FromQuery] Guid id)
        {
            var apartment = await _db.Apartments.GetById(id);
            if (apartment == null)
            {
                return NotFound();
            }

            var user = (await _db.Explorers.GetByFiler(q => q.Id == User.GetUserId())).First();
            if (user.State == ExplorerState.Banned)
            {
                TempData["alert-msg"] = "You are banned until " + user.DateFromState?.ToShortDateString();
                return Forbid();
            }

            RentCreateVM model = new RentCreateVM();
            model.ApartmentId = apartment.Id;
            model.MaxDurationInDays = apartment.MaxDurationInDays;
            model.StartDate = DateTime.Now.AddDays(1);
            model.EndDate = DateTime.Now.AddDays(apartment.MaxDurationInDays);
            return View(model);
        }

        public async Task<ActionResult> CreateItem(RentCreateVM model)
        {
            if (!ModelState.IsValid) { return View("Create", model); }

            Rent rent = new Rent();
            rent.ApartmentId = model.ApartmentId;
            rent.ExplorerId = User.GetUserId();
            rent.StartDate = model.StartDate;
            rent.EndDate = model.EndDate;
            rent.State = RentState.Requested;
            await _db.Rents.Add(rent);

            Apartment apartment = await _db.Apartments.GetById(model.ApartmentId);
            apartment.State = ApartmentState.Inactive;
            await _db.Apartments.Update(apartment);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFeedback(RentCreateFeedbackVM input)
        {
            Rate rate = new Rate();
            rate.ApartmentId = input.ApartmentId;
            rate.RentId = input.RentId;
            rate.Value = input.Rate;
            await _db.Rates.Add(rate);

            return RedirectToAction(nameof(Index), new { RentId = input.RentId });
        }
    }
}
