using AtoTax.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AtoTax.API.GenericRepository
{
    public interface IRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, params string[] allIncludeStrings);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, params string[] allIncludeStrings);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
