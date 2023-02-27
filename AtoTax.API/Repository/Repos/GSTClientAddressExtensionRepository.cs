using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTClientAddressExtensionRepository : Repository<GSTClientAddressExtension>, IGSTClientAddressExtensionRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<GSTClientAddressExtension> _logger;
        public GSTClientAddressExtensionRepository(AtoTaxDbContext context, ILogger<GSTClientAddressExtension> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<GSTClientAddressExtension> UpdateAsync(GSTClientAddressExtension entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
