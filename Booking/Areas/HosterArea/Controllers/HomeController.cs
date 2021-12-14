using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return Redirect("/HosterArea/Apartment");
        }
    }
}
