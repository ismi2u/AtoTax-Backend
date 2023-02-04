using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class ServiceCategoryRepository : Repository<ServiceCategory>, IServiceCategoryRepository
    {
        private readonly AtoTaxDbContext _context;
        public ServiceCategoryRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<ServiceCategory> UpdateAsync(ServiceCategory entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
