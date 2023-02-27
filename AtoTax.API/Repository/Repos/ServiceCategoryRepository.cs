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
        private readonly new ILogger<ServiceCategory> _logger;
        public ServiceCategoryRepository(AtoTaxDbContext context, ILogger<ServiceCategory> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<ServiceCategory> UpdateAsync(ServiceCategory entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
