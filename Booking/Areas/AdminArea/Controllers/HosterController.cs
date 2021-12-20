using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.AdminArea;
using Booking.DAL.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    public class HosterController : AdminAreaController<Hoster>
    {
        private readonly IHosterRepository _db;

        public HosterController(IHosterRepository db) : base(db)
        {
            _db = db;
        }

        public override async Task<ActionResult> CreateOrEdit(Guid id)
        {
            var item = await _db.GetById(id);
            if (item != null) { return View(item.Adapt<HosterCreateEditVM>()); }

            HosterCreateEditVM model = new HosterCreateEditVM();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVM(HosterCreateEditVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", input);
            }

            await _db.Add(input.Adapt<Hoster>());
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> EditVM(HosterCreateEditVM input)
        {
            if (!ModelState.IsValid) { return View("CreateOrEdit", input); }

            await _db.Update(input.Adapt<Hoster>());
            return RedirectToAction(nameof(Index));
        }
    }
}
