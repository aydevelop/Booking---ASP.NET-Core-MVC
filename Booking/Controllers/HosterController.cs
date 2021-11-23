using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Controllers
{
    public class HosterController : Controller
    {
        private readonly AppDbContext _db;

        public HosterController(AppDbContext db) => _db = db;

        public IActionResult Index()
        {
            var hosters = _db.Hosters.ToList();
            return View(hosters);
        }

        public ActionResult Details(int id)
        {
            var hoster = _db.Hosters.FirstOrDefault(q => q.Id == id);
            if (hoster == null) { return NotFound(); }
            return View(hoster);
        }

        public ActionResult CreateOrEdit(int id)
        {
            var hoster = _db.Hosters.FirstOrDefault(s => s.Id == id);
            return View(hoster != null ? hoster : new Hoster());
        }

        [HttpPost]
        public ActionResult Create(Hoster hoster)
        {
            if (!ModelState.IsValid) { return View(hoster); }

            _db.Hosters.Add(hoster);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Hoster hoster)
        {
            if (!ModelState.IsValid) { return View(hoster); }
            var item = _db.Apartments.FirstOrDefault(s => s.Id == hoster.Id);
            if (hoster == null) { return NotFound(); }

            _db.Hosters.Update(hoster);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            var item = _db.Hosters.FirstOrDefault(s => s.Id == id);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteHoster(int id)
        {
            var hoster = _db.Hosters.FirstOrDefault(s => s.Id == id);
            if (hoster == null) { return NotFound(); }

            _db.Hosters.Remove(hoster);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
