using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class MediaTypeRepository : Repository<MediaType>, IMediaTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        public MediaTypeRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<MediaType> UpdateAsync(MediaType entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
