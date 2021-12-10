using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ExplorerController : BaseController<Explorer>
    {
        private readonly IExplorerRepository _db;

        public ExplorerController(IExplorerRepository db) : base(db)
        {
            _db = db;
        }
    }
}
