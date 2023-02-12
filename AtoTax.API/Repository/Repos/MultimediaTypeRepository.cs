using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class MultimediaTypeRepository : Repository<MultimediaType>, IMultimediaTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<MultimediaType> _logger;
        public MultimediaTypeRepository(AtoTaxDbContext context, ILogger<MultimediaType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<MultimediaType> UpdateAsync(MultimediaType entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
