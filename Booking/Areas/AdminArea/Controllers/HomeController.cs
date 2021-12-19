using Booking.BLL.Contracts;
using Booking.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Areas.Admin.Controllers
{
    public class HomeController : AdminAreaController
    {
        private readonly IRepositories _db;

        public HomeController(IRepositories db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            HomeIndexVM model = new HomeIndexVM();
            model.RentsList = await _db.Rents.GetWithInclude(new[] { "Explorer", "Apartment" });
            model.ApartmentsList = await _db.Apartments.GetApartmentsWithDependencies();
            model.Hosters = await _db.Rents.Count();
            model.Explorers = await _db.Explorers.Count();
            model.Features = await _db.Features.Count();
            model.Locations = await _db.Locations.Count();

            return View(model);
        }

        public async Task<ActionResult> Complaints()
        {
            var complaints = await _db.Complaints.GetWithInclude(new[] { "Hoster", "Explorer" });
            return View(complaints);
        }
    }
}
