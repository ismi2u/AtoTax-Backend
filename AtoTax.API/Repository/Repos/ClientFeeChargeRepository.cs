using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtoTax.API.Repository.Repos
{
    public class ClientFeeChargeRepository : Repository<ClientFeeCharge>, IClientFeeChargeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ClientFeeCharge> _logger;
        public ClientFeeChargeRepository(AtoTaxDbContext context, ILogger<ClientFeeCharge> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<ClientFeeCharge> UpdateAsync(ClientFeeCharge entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("ClientFeeCharge Id" + entity.Id.ToString() + " updated");

            return entity;
        }
    }
}
