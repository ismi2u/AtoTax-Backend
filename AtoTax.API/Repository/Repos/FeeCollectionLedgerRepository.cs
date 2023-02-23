using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AccountsLedgerRepository : Repository<AccountsLedger>, IAccountsLedgerRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<AccountsLedger> _logger;
        public AccountsLedgerRepository(AtoTaxDbContext context, ILogger<AccountsLedger> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<AccountsLedger> UpdateAsync(AccountsLedger entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
