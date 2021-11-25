using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
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

        public override ActionResult CreateOrEdit(int id)
        {
            ViewBag.Hosters = _db.Hosters.Where(q => q.State == HosterState.Active).ToList();
            ViewBag.Locations = _db.Locations.Where(q => q.State == LocationState.Active).ToList();

            return base.CreateOrEdit(id);
        }

        [HttpPost]
        public override ActionResult Create(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Hosters = _db.Hosters.Where(q => q.State == HosterState.Active).ToList();
                ViewBag.Locations = _db.Locations.Where(q => q.State == LocationState.Active).ToList();
            }

            return base.Create(input);
        }

        [HttpPost]
        public override ActionResult Edit(Apartment input)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Hosters = _db.Hosters.Where(q => q.State == HosterState.Active).ToList();
                ViewBag.Locations = _db.Locations.Where(q => q.State == LocationState.Active).ToList();
            }

            return base.Edit(input);
        }
    }
}
