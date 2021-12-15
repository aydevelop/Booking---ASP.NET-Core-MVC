using Booking.BLL.Contracts;
using Booking.DAL;
using Booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booking.BLL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        private async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public ValueTask<T> GetById(Guid id)
        {
            return _db.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return _db.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public Task<List<T>> GetByFiler(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetByFilerWithInclude(Expression<Func<T, bool>> predicate, IEnumerable<string> tables)
        {
            var query = _db.Set<T>().AsQueryable();
            foreach (string table in tables)
            {
                query = query.Include(table);
            }

            return query.Where(predicate).ToListAsync();
        }

        public Task Add(T entity)
        {
            _db.Add(entity);
            return SaveAsync();
        }

        public Task Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveAsync();
        }

        public Task Delete(T entity)
        {
            _db.Remove(entity);
            return SaveAsync();
        }

        public Task<int> Count()
        {
            return _db.Set<T>().CountAsync();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).CountAsync();
        }

        public Task<List<T>> GetWithInclude(IEnumerable<string> tables)
        {
            var query = _db.Set<T>().AsQueryable();
            foreach (string table in tables)
            {
                query = query.Include(table);
            }

            return query.ToListAsync();
        }


    }
}
