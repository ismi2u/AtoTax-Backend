using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class DefaultChargeRepository : Repository<DefaultCharge>, IDefaultChargeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<DefaultCharge> _logger;
        public DefaultChargeRepository(AtoTaxDbContext context, ILogger<DefaultCharge> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<DefaultCharge> UpdateAsync(DefaultCharge entity)
        {

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
