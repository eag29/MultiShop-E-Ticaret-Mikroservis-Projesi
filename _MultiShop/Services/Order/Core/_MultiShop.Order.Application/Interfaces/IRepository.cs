﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
