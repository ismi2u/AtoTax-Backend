using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IAddressTypeRepository : IRepository<AddressType>
    {

        Task<AddressType> UpdateAsync(AddressType entity);
    }
}
