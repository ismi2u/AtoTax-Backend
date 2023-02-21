using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AtoTax.API.Repository.Repos
{
    public class MonthYearRepository : IMonthYearRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<MonthYear> _logger;
        private AtoTaxDbContext context;

     
        public MonthYearRepository(AtoTaxDbContext context, ILogger<MonthYear> logger) 
        {

            _context = context;
            _logger = logger;
        }

        public Task CreateAsync(MonthYear entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<MonthYear>> GetAllAsync(Expression<Func<MonthYear, bool>> filter = null, params string[] allIncludeStrings)
        {
            throw new NotImplementedException();
        }

        public Task<MonthYear> GetAsync(Expression<Func<MonthYear, bool>> filter = null, bool tracked = true, params string[] allIncludeStrings)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(MonthYear entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MonthYear> UpdateAsync(MonthYear entity)
        {
            throw new NotImplementedException();
        }
    }
}
