using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.HosterArea.Controllers
{
    [Area("HosterArea")]
    [Authorize(Roles = "hoster")]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return Redirect("/HosterArea/Apartment");
        }
    }
}
