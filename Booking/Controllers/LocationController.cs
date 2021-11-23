using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _db;

        public LocationController(AppDbContext db) => _db = db;

        public ActionResult Index()
        {
            var locations = _db.Locations.ToList();
            return View(locations);
        }

        public ActionResult Details(int id)
        {
            var location = _db.Locations.FirstOrDefault(q => q.Id == id);
            if (location == null) { return NotFound(); }
            return View(location);
        }

        public ActionResult CreateOrEdit(int id)
        {
            var location = _db.Locations.FirstOrDefault(s => s.Id == id);
            return View(location != null ? location : new Location());
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (!ModelState.IsValid) { return View(location); }

            _db.Locations.Add(location);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (!ModelState.IsValid) { return View(location); }
            var item = _db.Locations.FirstOrDefault(s => s.Id == location.Id);
            if (item == null) { return NotFound(); }

            _db.Entry(item).CurrentValues.SetValues(location);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var item = _db.Locations.FirstOrDefault(s => s.Id == id);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteLocation(int id)
        {
            var location = _db.Locations.FirstOrDefault(s => s.Id == id);
            if (location == null) { return NotFound(); }

            _db.Locations.Remove(location);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
