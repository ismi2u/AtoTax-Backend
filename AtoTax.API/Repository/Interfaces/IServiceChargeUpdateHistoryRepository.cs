using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IServiceChargeUpdateHistoryRepository : IRepository<ServiceChargeUpdateHistory>
    {

        Task<ServiceChargeUpdateHistory> UpdateAsync(ServiceChargeUpdateHistory entity);
    }
}
