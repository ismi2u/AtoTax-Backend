using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.IRepository
{
    public interface IGSTClientRepository: IRepository<GSTClient>
    {

        Task<GSTClient> UpdateAsync(GSTClient entity);
    }
}
