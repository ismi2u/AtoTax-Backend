using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IMediaTypeRepository : IRepository<MediaType>
    {

        Task<MediaType> UpdateAsync(MediaType entity);
    }
}
