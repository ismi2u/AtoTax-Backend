using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtoTax.API.Repository.Repos
{
    public class ClientFeeMapRepository : Repository<ClientFeeMap>, IClientFeeMapRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ClientFeeMap> _logger;
        public ClientFeeMapRepository(AtoTaxDbContext context, ILogger<ClientFeeMap> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<ClientFeeMap> UpdateAsync(ClientFeeMap entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("ClientFeeMap Id" + entity.Id.ToString() + " updated");

            return entity;
        }
    }
}
