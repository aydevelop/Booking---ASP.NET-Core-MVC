using Booking.DAL;
using Booking.DAL.Enums;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Booking.Controllers
{
    public class ApartmentController : BaseController<Apartment>
    {
        private readonly AppDbContext _db;

        public ApartmentController(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override ActionResult Index()
        {

            var items = _db.Apartments
                .Include(q => q.Hoster)
                .Include(q => q.Location)
                .ToList();

            return View(items);
        }

        public override ActionResult CreateOrEdit(int id)
        {
            LoadHostersLocations();
            return base.CreateOrEdit(id);
        }

        [HttpPost]
        public override ActionResult Create(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                LoadHostersLocations();
            }

            return base.Create(input);
        }

        [HttpPost]
        public override ActionResult Edit(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                LoadHostersLocations();
            }

            return base.Edit(input);
        }

        private void LoadHostersLocations()
        {
            ViewBag.Hosters = _db.Hosters.Where(q => q.State == HosterState.Active).ToList();
            ViewBag.Locations = _db.Locations.Where(q => q.State == LocationState.Active).ToList();
        }
    }
}
