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
        //private readonly ILogger<GSTClient> _logger;
        public GSTClientRepository(AtoTaxDbContext context, ILogger<GSTClient> logger) : base(context, logger)
        {

            _context = context;
            //_logger = logger;
        }


        public async Task<GSTClient> UpdateAsync(GSTClient entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
