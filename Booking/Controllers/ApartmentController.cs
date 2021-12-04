using Booking.BLL.Contracts;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class ApartmentController : BaseController<Apartment>
    {
        private readonly IApartmentRepository _dbApartment;
        private readonly IHosterRepository _dbHoster;
        private readonly ILocationRepository _dbLocation;

        public ApartmentController(IApartmentRepository dbApartment,
            IHosterRepository dbHoster,
            ILocationRepository dbLocation) : base(dbApartment)
        {
            _dbApartment = dbApartment;
            _dbHoster = dbHoster;
            _dbLocation = dbLocation;
        }

        public override async Task<ActionResult> Index()
        {
            var items = await _dbApartment.GetWithInclude(new[] { "Location", "Hoster" });
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
            ViewBag.Hosters = await _dbHoster.GetByFiler(q => q.State == HosterState.Active);
            ViewBag.Locations = await _dbLocation.GetByFiler(q => q.State == LocationState.Active);
        }
    }
}
