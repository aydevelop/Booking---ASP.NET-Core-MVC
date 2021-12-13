using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.HosterArea;
using Booking.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Booking.Areas.HosterArea.Components
{
    public class HosterMenu : ViewComponent
    {
        private readonly IRepositories _db;
        public HosterMenu(IRepositories db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var rents = _db.Rents.GetAll().Result;
            HosterMenuVM model = new HosterMenuVM();
            model.ApprovedCount = rents.Where(q => q.State == RentState.Approved).Count();
            model.RejectedCount = rents.Where(q => q.State == RentState.Rejected).Count();
            model.InactiveCount = rents.Where(q => q.State == RentState.Inactive).Count();
            model.RequestedCount = rents.Where(q => q.State == RentState.Requested).Count();

            return View(model);
        }
    }
}
