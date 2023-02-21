using AtoTax.API.GenericRepository;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using System.Linq.Expressions;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IMonthYearRepository 
    {
        Task<List<MonthYear>> GetAllAsync(Expression<Func<MonthYear, bool>>? filter = null, params string[] allIncludeStrings);
        Task<MonthYear> GetAsync(Expression<Func<MonthYear, bool>>? filter = null, bool tracked = true, params string[] allIncludeStrings);
        Task CreateAsync(MonthYear entity);
        Task RemoveAsync(MonthYear entity);
        Task SaveAsync();
        Task<MonthYear> UpdateAsync(MonthYear entity);
    }
}
