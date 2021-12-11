using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Areas.Admin.Controllers
{
    public class ExplorerController : AdminAreaController<Explorer>
    {
        private readonly IExplorerRepository _db;

        public ExplorerController(IExplorerRepository db) : base(db)
        {
            _db = db;
        }
    }
}
