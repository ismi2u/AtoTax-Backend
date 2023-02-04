using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTClientRepository : IRepository<GSTClient>
    {

        Task<GSTClient> UpdateAsync(GSTClient entity);
    }
}
