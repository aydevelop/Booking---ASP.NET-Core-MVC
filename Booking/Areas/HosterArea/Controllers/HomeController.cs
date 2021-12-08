using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/HosterArea/Apartment");
        }
    }
}
