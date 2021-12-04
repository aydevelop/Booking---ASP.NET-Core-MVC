using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [Route("/HandleError/{code:int}")]
        public ActionResult HandleError(int code = 500)
        {
            ViewData["Message"] = $"Error occurred with ErrorCode: {code}";
            return View("Error");
        }

        [Route("/ExceptionHandler")]
        public ActionResult ExceptionHandler()
        {
            ViewData["Message"] = $"Exception occurred with RequestId: {HttpContext.TraceIdentifier}";
            return View("Error");
        }
    }
}
