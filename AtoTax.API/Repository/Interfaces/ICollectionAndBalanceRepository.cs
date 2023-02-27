using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface ICollectionAndBalanceRepository : IRepository<CollectionAndBalance>
    {

        Task<CollectionAndBalance> UpdateAsync(CollectionAndBalance entity);

        Task SyncDataAsync();
    }
}
