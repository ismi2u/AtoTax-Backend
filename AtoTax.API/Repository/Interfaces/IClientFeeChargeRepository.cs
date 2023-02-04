using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IClientFeeChargeRepository : IRepository<ClientFeeCharge>
    {

        Task<ClientFeeCharge> UpdateAsync(ClientFeeCharge entity);
    }
}
