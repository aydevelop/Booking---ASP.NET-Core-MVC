using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.BLL.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        private readonly AppDbContext _db;

        public ApartmentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<List<Apartment>> GetWithHosterAndLocation()
        {
            throw new System.NotImplementedException();
        }
    }
}
