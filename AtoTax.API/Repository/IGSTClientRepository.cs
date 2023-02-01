using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository
{
    public interface IGSTClientRepository
    {

        Task<List<GSTClient>> GetAll();

        Task Create (GSTClient gstClient);
        Task Remove (GSTClient gstClient);
        Task Save (GSTClient gstClient);
    }
}
