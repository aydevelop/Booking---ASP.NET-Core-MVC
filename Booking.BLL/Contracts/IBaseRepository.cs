﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Booking.BLL.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetByFiler(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetWithInclude(IEnumerable<string> tables);
    }
}