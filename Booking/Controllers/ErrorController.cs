using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class ErrorController
    {
        public ActionResult<int> Error(int code)
        {
            return (code);
        }
    }
}
