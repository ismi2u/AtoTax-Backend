using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IServiceCategoryRepository : IRepository<ServiceCategory>
    {

        Task<ServiceCategory> UpdateAsync(ServiceCategory entity);
    }
}
