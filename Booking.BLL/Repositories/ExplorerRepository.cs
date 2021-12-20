using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;
using System;
using System.Threading.Tasks;

namespace Booking.BLL.Repositories
{
    public class ExplorerRepository : BaseRepository<Explorer>, IExplorerRepository
    {
        private readonly AppDbContext _db;

        public ExplorerRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override Task Update(Explorer entity)
        {
            var item = _db.Explorers.Find(entity.Id.ToString());
            item.FirstName = entity.FirstName;
            item.LastName = entity.LastName;
            item.State = entity.State;
            item.Birthday = entity.Birthday;
            item.State = entity.State;
            item.Email = entity.Email;
            item.DateFromState = entity.DateFromState;

            if (entity.DateFromState != null)
            {
                item.State = DAL.Enums.ExplorerState.Banned;
            }

            _db.Explorers.Update(item);
            return _db.SaveChangesAsync();
        }

        public override Task Add(Explorer entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _db.Explorers.Add(entity);
            return _db.SaveChangesAsync();
        }
    }
}