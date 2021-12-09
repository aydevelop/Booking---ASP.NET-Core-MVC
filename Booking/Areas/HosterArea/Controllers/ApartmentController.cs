using Booking.BLL.Contracts;
using Booking.BLL.ViewModels;
using Booking.BLL.ViewModels.Data;
using Booking.Controllers;
using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    public class ApartmentController : BaseController<Apartment>
    {
        private readonly IRepositories _db;
        private readonly AppDbContext _context;

        public ApartmentController(IRepositories db, AppDbContext context) : base(db.Apartments)
        {
            _db = db;
            _context = context;
        }

        public override async Task<ActionResult> Index()
        {
            var items = await _db.Apartments.GetApartmentsWithDependencies();
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
                model.AssignedFeatures = item.AssignedFeatures;
                return View("Create", model);
            }

            Apartment aprt = item.apartment;
            await _db.Apartments.Add(aprt);
            foreach (var data in item.AssignedFeatures.Where(q => q.Assigned))
            {
                var ftr = await _db.Features.GetByFiler(q => q.Name == data.FeatureName);
                var first = ftr.FirstOrDefault();
                if (first != null)
                {
                    await _db.ApartmentFeatures.Add(new ApartmentFeature() { ApartmentId = aprt.Id, FeatureId = first.Id });
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var item = await _db.Apartments.GetById(id);
            if (item == null) { return NotFound(); }
            var allApFeat = await _db.ApartmentFeatures.GetAll();
            var allFeat = await _db.Features.GetAll();

            List<AssignedFeatureData> assignFeat = new List<AssignedFeatureData>();
            foreach (var feature in allFeat)
            {
                assignFeat.Add(new AssignedFeatureData()
                {
                    FeatureName = feature.Name,
                    Assigned = allApFeat.Find(q =>
                        q.ApartmentId == item.Id && q.FeatureId == feature.Id) == null ? false : true,
                    FeatureId = feature.Id
                });
            }

            HosterApartmentCreateVM model = new HosterApartmentCreateVM();
            model.apartment = item;
            model.Locations = await _db.Locations.GetAll();
            model.Hosters = await _db.Hosters.GetAll();
            model.AssignedFeatures = assignFeat;
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> EditItem(HosterApartmentCreateVM item)
        {
            var aprtCheck = await _db.Apartments.GetById(item.apartment.Id);
            if (aprtCheck == null) { return NotFound(); }
            Apartment aprt = item.apartment;
            await _db.Apartments.Update(aprt);

            var allApFeat = await _db.ApartmentFeatures.GetAll();
            foreach (var apFeat in allApFeat)
            {
                if (apFeat.ApartmentId == aprtCheck.Id)
                {
                    await _db.ApartmentFeatures.Delete(apFeat);
                }
            }

            foreach (var assigFeat in item.AssignedFeatures)
            {
                if (assigFeat.Assigned)
                {
                    await _db.ApartmentFeatures.Add(new ApartmentFeature()
                    {
                        ApartmentId = aprtCheck.Id,
                        FeatureId = assigFeat.FeatureId
                    });
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
