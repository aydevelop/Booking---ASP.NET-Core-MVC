using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Controllers
{
    public class BaseController<T> : Controller where T : BaseModel, new()
    {
        private readonly AppDbContext _db;

        protected BaseController(AppDbContext db) => _db = db;

        public virtual ActionResult Index()
        {
            var items = _db.Set<T>().ToList();
            return View(items);
        }

        public virtual ActionResult Details(int id)
        {
            var item = _db.Set<T>().FirstOrDefault(q => q.Id == id);
            if (item == null) { return NotFound(); }
            return View(item);
        }

        public virtual ActionResult CreateOrEdit(int id)
        {
            var item = _db.Set<T>().FirstOrDefault(s => s.Id == id);
            return View(item != null ? item : new T());
        }

        [HttpPost]
        public virtual ActionResult Create(T input)
        {
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.ToDictionary(
    kvp => kvp.Key,
    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
);

                return View("CreateOrEdit", input);
            }

            _db.Add(input);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public virtual ActionResult Edit(T input)
        {
            if (!ModelState.IsValid) { return View("CreateOrEdit", input); }
            var item = _db.Set<T>().FirstOrDefault(s => s.Id == input.Id);
            if (item == null) { return NotFound(); }

            _db.Entry(item).CurrentValues.SetValues(input);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public virtual ActionResult Delete(int id)
        {
            var item = _db.Set<T>().FirstOrDefault(s => s.Id == id);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        [HttpPost]
        public virtual IActionResult DeleteLocation(int id)
        {
            var item = _db.Set<T>().FirstOrDefault(s => s.Id == id);
            if (item == null) { return NotFound(); }

            _db.Set<T>().Remove(item);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
