using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;
using System;
using System.Threading.Tasks;

namespace Booking.BLL.Repositories
{
    public class HosterRepository : BaseRepository<Hoster>, IHosterRepository
    {
        private readonly AppDbContext _db;
        public HosterRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override Task Update(Hoster entity)
        {
            var item = _db.Hosters.Find(entity.Id.ToString());
            item.FirstName = entity.FirstName;
            item.LastName = entity.LastName;
            item.State = entity.State;

            _db.Hosters.Update(item);
            return _db.SaveChangesAsync();
        }

        public override Task Add(Hoster entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _db.Hosters.Add(entity);
            return _db.SaveChangesAsync();
        }
    }
}
