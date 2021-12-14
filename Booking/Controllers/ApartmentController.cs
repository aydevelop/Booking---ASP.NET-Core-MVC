using Booking.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IRepositories _db;

        public ApartmentController(IRepositories db)
        {
            this._db = db;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _db.Apartments.GetApartmentsWithDependencies();
            var apartments = results.Where(q => q.State == DAL.Enums.ApartmentState.Active).ToList();

            return View(apartments);
        }
    }
}
