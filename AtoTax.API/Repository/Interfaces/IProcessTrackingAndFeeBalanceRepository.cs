using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IProcessTrackingAndFeeBalanceRepository : IRepository<ProcessTrackingAndFeeBalance>
    {

        Task<ProcessTrackingAndFeeBalance> UpdateAsync(ProcessTrackingAndFeeBalance entity);

        Task SyncMonthlyDataAsync();
        Task SyncAnnualDataAsync();
        Task SyncQuaterlyDataAsync();
    }
}
