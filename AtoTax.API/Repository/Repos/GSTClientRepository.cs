using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTClientRepository : Repository<GSTClient>, IGSTClientRepository
    {
        private readonly AtoTaxDbContext _context;
        public GSTClientRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<GSTClient> UpdateAsync(GSTClient entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
