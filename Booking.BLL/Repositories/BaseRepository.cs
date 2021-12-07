using Booking.BLL.Contracts;
using Booking.DAL;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booking.BLL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        private async Task SaveAsync()
        {
            var policy = Policy.Handle<Exception>().WaitAndRetryAsync(new[]
            {
                TimeSpan.FromMilliseconds(100),
                TimeSpan.FromMilliseconds(200),
                TimeSpan.FromMilliseconds(300),
                TimeSpan.FromMilliseconds(400),
            });

            await policy.ExecuteAsync(async () => await _db.SaveChangesAsync());
        }

        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return _db.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public async Task<List<T>> GetByFiler(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task Add(T entity)
        {
            _db.Add(entity);
            await SaveAsync();
        }

        public async Task Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            await SaveAsync();
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
