using AtoTax.API.Repository.IRepository;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository
{
    public class GSTClientRepository : Repository<GSTClient>, IGSTClientRepository
    {
        private readonly AtoTaxDbContext _context;
        public GSTClientRepository(AtoTaxDbContext context) :base(context) 
        {

            _context = context;
        }
        public async Task<GSTClient> UpdateAsync(GSTClient entity)
        {
            var oldGSTclient = await _context.GSTClients.AsNoTracking().FirstOrDefaultAsync(g => g.Id == entity.Id);
            
            entity.GSTIN = oldGSTclient.GSTIN;
            entity.UpdatedOn = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
