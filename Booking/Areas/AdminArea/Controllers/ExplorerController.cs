using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.AdminArea;
using Booking.DAL.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    public class ExplorerController : AdminAreaController<Explorer>
    {
        private readonly IExplorerRepository _db;

        public ExplorerController(IExplorerRepository db) : base(db)
        {
            _db = db;
        }

        public override async Task<ActionResult> CreateOrEdit(Guid id)
        {
            var item = await _db.GetById(id);
            if (item != null) { return View(item.Adapt<ExplorerCreateEditVM>()); }

            ExplorerCreateEditVM model = new ExplorerCreateEditVM();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVM(ExplorerCreateEditVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrEdit", input);
            }

            await _db.Add(input.Adapt<Explorer>());
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> EditVM(ExplorerCreateEditVM input)
        {
            if (!ModelState.IsValid) { return View("CreateOrEdit", input); }

            await _db.Update(input.Adapt<Explorer>());
            return RedirectToAction(nameof(Index));
        }
    }
}
