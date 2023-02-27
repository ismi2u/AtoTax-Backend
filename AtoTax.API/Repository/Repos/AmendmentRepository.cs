using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AmendmentRepository : Repository<Amendment>, IAmendmentRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<Amendment> _logger;
        public AmendmentRepository(AtoTaxDbContext context, ILogger<Amendment> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }

        public async Task<Amendment> UpdateAsync(Amendment entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }

    }
}
