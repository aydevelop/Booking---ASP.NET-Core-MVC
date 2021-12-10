using Booking.BLL.Contracts;
using Booking.Controllers;
using Booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class FeatureController : BaseController<Feature>
    {
        private readonly IFeatureRepository _db;

        public FeatureController(IFeatureRepository db) : base(db)
        {
            _db = db;
        }
    }
}
