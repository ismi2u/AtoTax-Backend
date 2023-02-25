using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AccountLedgerRepository : Repository<AccountLedger>, IAccountLedgerRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<AccountLedger> _logger;
        public AccountLedgerRepository(AtoTaxDbContext context, ILogger<AccountLedger> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<AccountLedger> UpdateAsync(AccountLedger entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
