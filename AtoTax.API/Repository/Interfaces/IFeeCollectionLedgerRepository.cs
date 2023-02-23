using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IAccountsLedgerRepository : IRepository<AccountsLedger>
    {

        Task<AccountsLedger> UpdateAsync(AccountsLedger entity);
    }
}
