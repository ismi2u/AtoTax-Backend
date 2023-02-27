using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTFilingTypeRepository : Repository<GSTFilingType>, IGSTFilingTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<GSTFilingType> _logger;
        public GSTFilingTypeRepository(AtoTaxDbContext context, ILogger<GSTFilingType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<GSTFilingType> UpdateAsync(GSTFilingType entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
