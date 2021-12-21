using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public Task<List<Apartment>> GetApartmentsWithDependencies()
        {
            var query = _db.Apartments
                .Include(q => q.Features).ThenInclude(f => f.Feature)
                .Include(q => q.Hoster)
                .Include(q => q.Rates)
                .Include(q => q.Location);

            return query.ToListAsync();
        }
    }
}
