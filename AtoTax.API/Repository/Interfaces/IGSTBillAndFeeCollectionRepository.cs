using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTBillAndFeeCollectionRepository : IRepository<GSTBillAndFeeCollection>
    {

        Task<GSTBillAndFeeCollection> UpdateAsync(GSTBillAndFeeCollection entity);
    }
}
