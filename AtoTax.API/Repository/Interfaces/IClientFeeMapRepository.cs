using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IClientFeeMapRepository : IRepository<ClientFeeMap>
    {

        Task<ClientFeeMap> UpdateAsync(ClientFeeMap entity);
    }
}
