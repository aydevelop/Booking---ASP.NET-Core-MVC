using Booking.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.BLL.Contracts
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<List<Apartment>> GetWithHosterAndLocation();
    }
}
