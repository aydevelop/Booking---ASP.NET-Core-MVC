using Booking.BLL.Contracts;
using Booking.BLL.ViewModels.HosterArea;
using Booking.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Areas.HosterArea.Components
{
    public class HosterMenu : ViewComponent
    {
        private readonly IRepositories _db;
        public HosterMenu(IRepositories db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rents = await _db.Rents.GetAll();
            HosterMenuVM model = new HosterMenuVM();
            model.ApprovedCount = rents.Where(q => q.State == RentState.Approved).Count();
            model.RejectedCount = rents.Where(q => q.State == RentState.Rejected).Count();
            model.InactiveCount = rents.Where(q => q.State == RentState.Inactive).Count();
            model.RequestedCount = rents.Where(q => q.State == RentState.Requested).Count();

            return View(model);
        }
    }
}
