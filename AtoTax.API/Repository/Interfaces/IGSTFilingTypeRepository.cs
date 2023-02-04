using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTFilingTypeRepository : IRepository<GSTFilingType>
    {

        Task<GSTFilingType> UpdateAsync(GSTFilingType entity);
    }
}
