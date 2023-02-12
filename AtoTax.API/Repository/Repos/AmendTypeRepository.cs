using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AmendTypeRepository : Repository<AmendType>, IAmendTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<AmendType> _logger;
        public AmendTypeRepository(AtoTaxDbContext context, ILogger<AmendType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<AmendType> UpdateAsync(AmendType entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
