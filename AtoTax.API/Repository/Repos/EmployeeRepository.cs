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
        public EmployeeRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
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
