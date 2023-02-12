using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IMultimediaTypeRepository : IRepository<MultimediaType>
    {

        Task<MultimediaType> UpdateAsync(MultimediaType entity);
    }
}
