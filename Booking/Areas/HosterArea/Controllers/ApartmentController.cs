using Booking.BLL.Contracts;
using Booking.BLL.ViewModels;
using Booking.BLL.ViewModels.Data;
using Booking.BLL.ViewModels.HosterArea;
using Booking.Controllers;
using Booking.DAL;
using Booking.DAL.Models;
using Booking.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    [Authorize(Roles = "hoster")]
    public class ApartmentController : BaseController<Apartment>
    {
        private readonly AppDbContext context;
        private readonly IRepositories _db;
        private readonly UserManager<IdentityUser> userManager;

        public ApartmentController(AppDbContext context, IRepositories db, UserManager<IdentityUser> userManager) : base(db.Apartments)
        {
            this.context = context;
            _db = db;
            this.userManager = userManager;
        }

        public override async Task<ActionResult> Index()
        {
            ApartmentIndexVM model = new ApartmentIndexVM();
            model.apartments = await _db.Apartments.GetApartmentsWithDependencies();
            var userId = User.GetUserId();
            model.apartments = model.apartments.Where(q => q.HosterId == userId).ToList();
            model.rents = await _db.Rents.GetWithInclude(new[] { "Explorer", "Apartment" });
            model.rents = model.rents.Where(q => q.Apartment.HosterId == userId).ToList();
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            ApartmentCreateVM model = new ApartmentCreateVM();
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
        public virtual async Task<ActionResult> CreateItem(ApartmentCreateVM item)
        {
            if (!ModelState.IsValid)
            {
                ApartmentCreateVM model = new ApartmentCreateVM();
                model = item;
                model.Hosters = await _db.Hosters.GetAll();
                model.Locations = await _db.Locations.GetAll();
                model.AssignedFeatures = item.AssignedFeatures;
                return View("Create", model);
            }

            Apartment aprt = item.apartment;
            aprt.HosterId = User.GetUserId();
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

        public async Task<ActionResult> Edit(Guid id)
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

            ApartmentCreateVM model = new ApartmentCreateVM();
            model.apartment = item;
            model.Locations = await _db.Locations.GetAll();
            model.Hosters = await _db.Hosters.GetAll();
            model.AssignedFeatures = assignFeat;
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> EditItem(ApartmentCreateVM item)
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

        public override async Task<ActionResult> Details(Guid? id)
        {
            if (id == null) { return BadRequest(); }
            var item = await _db.Apartments.GetByFilerWithInclude(q => q.Id == id, new[] { "Hoster", "Location" });

            var firstItem = item.FirstOrDefault();
            if (firstItem == null) { return NotFound(); }

            ApartmentDetailsVM model = new ApartmentDetailsVM();
            model.apartment = firstItem;
            List<Rent> rents = await _db.Rents
                .GetByFilerWithInclude(q => q.ApartmentId == id, new[] { "Explorer", "Apartment" });
            model.rents = rents.Take(10).ToList();

            return View(model);
        }

        [HttpPost]
        public override async Task<ActionResult> DeleteItem(Guid id)
        {
            var all = await _db.Apartments.GetByFilerWithInclude(q => q.Id == id, new[] { "Rates" });
            if (all.Count == 0) { return NotFound(); }
            Apartment item = all.First();

            foreach (Rate rate in item.Rates)
            {
                await _db.Rates.Delete(rate);
            }

            await _db.Apartments.Delete(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
