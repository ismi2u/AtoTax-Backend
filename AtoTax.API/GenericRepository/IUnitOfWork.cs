using AtoTax.API.Repository.Interfaces;

namespace AtoTax.API.GenericRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IClientMonthlyPaymentRepository ClientMonthlyPayments { get; }
        IMonthAndYearRepository MonthAndYears { get; }

        IAddressTypeRepository AddressTypes { get; }
        IAmendmentRepository Amendments { get; }
        IAmendTypeRepository AmendTypes { get; }
        IReturnFrequencyTypeRepository ReturnFrequencyTypes { get; }
        IClientFeeMapRepository ClientFeeMaps { get; }
        IProcessTrackingAndFeeBalanceRepository ProcessTrackingAndFeeBalances { get; }
        IGSTBillsProcessingRepository GSTBillsProcessings { get; }
        IGSTClientAddressExtensionRepository GSTClientAddressExtensions { get; }
        IAccountLedgerRepository AccountLedgers { get; }
        IGSTClientRepository GSTClients { get; }

        IGSTFilingTypeRepository GSTFilingTypes { get; }
        IGSTPaidDetailRepository GSTPaidDetails { get; }
        IMultimediaTypeRepository MultimediaTypes { get; }
        IPaymentTypeRepository PaymentTypes { get; }
        IReturnFrequencyTypeRepository ServiceCategories { get; }
        IStatusRepository Statuses { get; }
        IUserLoggedActivityRepository UserLoggedActivities { get; }
        IServiceChargeUpdateHistoryRepository ServiceChargeUpdateHistories { get; }

        Task CompleteAsync();
    }
}
