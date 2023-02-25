using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IAccountLedgerRepository : IRepository<AccountLedger>
    {

        Task<AccountLedger> UpdateAsync(AccountLedger entity);
    }
}
