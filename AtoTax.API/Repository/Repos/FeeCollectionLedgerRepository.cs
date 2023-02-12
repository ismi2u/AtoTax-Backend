using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class FeeCollectionLedgerRepository : Repository<FeeCollectionLedger>, IFeeCollectionLedgerRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<FeeCollectionLedger> _logger;
        public FeeCollectionLedgerRepository(AtoTaxDbContext context, ILogger<FeeCollectionLedger> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<FeeCollectionLedger> UpdateAsync(FeeCollectionLedger entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
