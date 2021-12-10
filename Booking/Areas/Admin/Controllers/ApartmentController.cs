using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ApartmentController : BaseController<Apartment>
    {
        private readonly IRepositories _db;

        public ApartmentController(IRepositories db) : base(db.Apartments)
        {
            _db = db;
        }
        public override async Task<ActionResult> Index()
        {
            var items = await _db.Apartments.GetWithInclude(new[] { "Location", "Hoster", "Features" });
            return View(items);
        }

        public override async Task<ActionResult> CreateOrEdit(int id)
        {
            await LoadHostersLocations();
            return await base.CreateOrEdit(id);
        }

        [HttpPost]
        public override async Task<ActionResult> Create(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                await LoadHostersLocations();
            }

            return await base.Create(input);
        }

        [HttpPost]
        public override async Task<ActionResult> Edit(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                await LoadHostersLocations();
            }

            return await base.Edit(input);
        }

        private async Task LoadHostersLocations()
        {
            ViewBag.Hosters = await _db.Hosters.GetByFiler(q => q.State == HosterState.Active);
            ViewBag.Locations = await _db.Locations.GetByFiler(q => q.State == LocationState.Active);
            ViewBag.Features = await _db.Features.GetByFiler(q => q.State == FeatureState.Active);
        }
    }
}
