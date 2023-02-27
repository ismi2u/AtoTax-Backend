using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTBillAndFeeCollectionRepository : Repository<GSTBillAndFeeCollection>, IGSTBillAndFeeCollectionRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<GSTBillAndFeeCollection> _logger;
        public GSTBillAndFeeCollectionRepository(AtoTaxDbContext context, ILogger<GSTBillAndFeeCollection> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<GSTBillAndFeeCollection> UpdateAsync(GSTBillAndFeeCollection entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
