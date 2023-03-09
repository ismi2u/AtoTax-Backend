using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTBillsProcessingRepository : IRepository<GSTBillsProcessing>
    {

        Task<GSTBillsProcessing> UpdateAsync(GSTBillsProcessing entity);
    }
}
