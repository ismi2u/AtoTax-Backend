using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class ServiceChargeUpdateHistoryRepository : Repository<ServiceChargeUpdateHistory>, IServiceChargeUpdateHistoryRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<ServiceChargeUpdateHistory> _logger;
        public ServiceChargeUpdateHistoryRepository(AtoTaxDbContext context, ILogger<ServiceChargeUpdateHistory> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<ServiceChargeUpdateHistory> UpdateAsync(ServiceChargeUpdateHistory entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
