using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IAmendTypeRepository : IRepository<AmendType>
    {

        Task<AmendType> UpdateAsync(AmendType entity);
    }
}
