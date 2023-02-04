using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTClientAddressExtensionRepository : IRepository<GSTClientAddressExtension>
    {

        Task<GSTClientAddressExtension> UpdateAsync(GSTClientAddressExtension entity);
    }
}
