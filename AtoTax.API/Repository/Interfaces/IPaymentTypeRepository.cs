using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        Task<PaymentType> UpdateAsync(PaymentType entity);
    }
}
