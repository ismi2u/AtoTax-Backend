using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IGSTPaidDetailRepository : IRepository<GSTPaidDetail>
    {

        Task<GSTPaidDetail> UpdateAsync(GSTPaidDetail entity);
    }
}
