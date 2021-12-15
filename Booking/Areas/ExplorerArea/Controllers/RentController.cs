using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.ExplorerArea;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Booking.Areas.ExplorerArea.Controllers
{
    [Authorize]
    [Area("ExplorerArea")]
    public class RentController : Controller
    {
        private readonly IRepositories _db;

        public RentController(IRepositories db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var rents = await _db.Rents.GetByFiler(q => q.ExplorerId == userId);

            return View(rents);
        }

        public async Task<ActionResult> Create([FromQuery] Guid id)
        {
            var apartment = await _db.Apartments.GetById(id);
            if (apartment == null)
            {
                return NotFound();
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
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Rent rent = new Rent();
            rent.ApartmentId = model.ApartmentId;
            rent.ExplorerId = userId;
            rent.StartDate = model.StartDate;
            rent.EndDate = model.EndDate;
            rent.State = RentState.Requested;
            //await _db.Rents.Add(rent);

            return RedirectToAction(nameof(Index));
        }
    }
}
