using Booking.BLL.Contracts;
using Booking.DAL.Models;

namespace Booking.Areas.Admin.Controllers
{
    public class FeatureController : AdminAreaController<Feature>
    {
        private readonly IFeatureRepository _db;

        public FeatureController(IFeatureRepository db) : base(db)
        {
            _db = db;
        }
    }
}
