using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<Employee> _logger;
        public EmployeeRepository(AtoTaxDbContext context, ILogger<Employee> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<Employee> UpdateAsync(Employee entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
