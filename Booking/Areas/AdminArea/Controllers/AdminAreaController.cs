using Booking.BLL.Contracts;
using Booking.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "admin")]
    public class AdminAreaController<T> : BaseController<T> where T : class, new()
    {
        public AdminAreaController(IRepository<T> db) : base(db)
        {
        }
    }

    [Area("AdminArea")]
    [Authorize(Roles = "admin")]
    public class AdminAreaController : Controller
    {

    }
}
