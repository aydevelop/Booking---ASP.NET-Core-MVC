using Booking.Areas.Admin.ViewModels;
using Booking.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IRepositories _db;

        public HomeController(IRepositories db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            AdminHomeIndexVM model = new AdminHomeIndexVM();
            model.Rents = await _db.Rents.GetWithInclude(new[] { "Explorer", "Apartment" });
            model.Hosters = await _db.Rents.Count();
            model.Explorers = await _db.Explorers.Count();
            model.Apartments = await _db.Apartments.Count();
            model.Features = await _db.Features.Count();
            model.Locations = await _db.Locations.Count();

            return View(model);
        }
    }
}
