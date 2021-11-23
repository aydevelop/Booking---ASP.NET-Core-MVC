using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly AppDbContext _db;

        public ApartmentController(AppDbContext db) => _db = db;

        public ActionResult Index()
        {
            var apartments = _db.Apartments.ToList();
            return View(apartments);
        }

        public ActionResult Details(int id)
        {
            var apartment = _db.Apartments.FirstOrDefault(q => q.Id == id);
            if (apartment == null) { return NotFound(); }
            return View(apartment);
        }

        public ActionResult CreateOrEdit(int id)
        {
            var apartment = _db.Apartments.FirstOrDefault(s => s.Id == id);
            return View(apartment != null ? apartment : new Apartment());
        }

        [HttpPost]
        public ActionResult Create(Apartment apartment)
        {
            if (!ModelState.IsValid) { return View(apartment); }

            _db.Apartments.Add(apartment);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Apartment apartment)
        {
            if (!ModelState.IsValid) { return View(apartment); }
            var item = _db.Apartments.FirstOrDefault(s => s.Id == apartment.Id);
            if (apartment == null) { return NotFound(); }

            _db.Apartments.Update(apartment);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var item = _db.Apartments.FirstOrDefault(s => s.Id == id);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteApartment(int id)
        {
            var apartment = _db.Apartments.FirstOrDefault(s => s.Id == id);
            if (apartment == null) { return NotFound(); }

            _db.Apartments.Remove(apartment);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
