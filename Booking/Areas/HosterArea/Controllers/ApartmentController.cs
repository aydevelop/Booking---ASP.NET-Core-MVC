using Booking.BLL.Contracts;
using Booking.BLL.ViewModels;
using Booking.BLL.ViewModels.Data;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
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

        public async Task<ActionResult> Create()
        {
            HosterApartmentCreateVM model = new HosterApartmentCreateVM();
            model.apartment = new Apartment();
            model.Hosters = await _db.Hosters.GetAll();
            model.Locations = await _db.Locations.GetAll();

            var features = await _db.Features.GetAll();
            model.AssignedFeatures = features.Select(f => new AssignedFeatureData
            {
                Assigned = false,
                FeatureId = f.Id,
                FeatureName = f.Name
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> CreateItem(HosterApartmentCreateVM item)
        {
            if (!ModelState.IsValid)
            {
                HosterApartmentCreateVM model = new HosterApartmentCreateVM();
                model = item;
                model.Hosters = await _db.Hosters.GetAll();
                model.Locations = await _db.Locations.GetAll();

                var features = await _db.Features.GetAll();
                model.AssignedFeatures = features.Select(f => new AssignedFeatureData
                {
                    Assigned = item.AssignedFeatures.FirstOrDefault(f2 => f2.FeatureId == f.Id) == null ? false : true,
                    FeatureId = f.Id,
                    FeatureName = f.Name
                }).ToList();

                return View("Create", model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
