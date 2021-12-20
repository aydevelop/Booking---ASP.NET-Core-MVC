using Booking.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class BaseController<T> : Controller where T : class, new()
    {
        private readonly IRepository<T> _db;

        public BaseController(IRepository<T> db) => _db = db;

        public virtual async Task<ActionResult> Index()
        {
            var items = await _db.GetAll();
            return View(items);
        }

        public virtual async Task<ActionResult> Details(Guid? id)
        {
            if (id == null) { return BadRequest(); }

            var item = await _db.GetById(id.Value);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        public virtual async Task<ActionResult> CreateOrEdit(Guid id)
        {
            var item = await _db.GetById(id);
            if (item != null) { return View(item); }

            var newItem = new T();
            return View(newItem);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(T input)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", input);
            }

            await _db.Add(input);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(T input)
        {
            if (!ModelState.IsValid) { return View("CreateOrEdit", input); }

            await _db.Update(input);
            return RedirectToAction(nameof(Index));
        }


        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var item = await _db.GetById(id);
            if (item == null) { return NotFound(); }

            return View(item);
        }

        [HttpPost]
        public virtual async Task<ActionResult> DeleteItem(Guid id)
        {
            T item = await _db.GetById(id);
            if (item == null) { return NotFound(); }

            await _db.Delete(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
