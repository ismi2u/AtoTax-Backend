using AtoTax.API.GenericRepository;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using System.Linq.Expressions;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IMonthAndYearRepository 
    {
        Task<List<MonthAndYear>> GetAllAsync(Expression<Func<MonthAndYear, bool>>? filter = null, params string[] allIncludeStrings);
        Task<MonthAndYear> GetAsync(Expression<Func<MonthAndYear, bool>>? filter = null, bool tracked = true, params string[] allIncludeStrings);
        Task CreateMonthYearAsync(int month, int year);
        Task RemoveAsync(MonthAndYear entity);
        Task SaveAsync();
        Task<MonthAndYear> UpdateAsync(MonthAndYear entity);
    }
}
