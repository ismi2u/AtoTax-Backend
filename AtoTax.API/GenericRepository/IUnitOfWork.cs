using AtoTax.API.Repository.Interfaces;

namespace AtoTax.API.GenericRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IClientMonthlyPaymentRepository ClientMonthlyPayments { get; }

        IAddressTypeRepository AddressTypes { get; }
        IAmendmentRepository Amendments { get; }
        IAmendTypeRepository AmendTypes { get; }
        IFrequencyRepository Frequencies { get; }
        IClientFeeMapRepository ClientFeeMaps { get; }
        ICollectionAndBalanceRepository CollectionAndBalances { get; }
        IGSTBillsProcessingRepository GSTBillsProcessings { get; }
        IGSTClientAddressExtensionRepository GSTClientAddressExtensions { get; }
        IAccountLedgerRepository AccountLedgers { get; }
        IGSTClientRepository GSTClients { get; }

        IGSTFilingTypeRepository GSTFilingTypes { get; }
        IGSTPaidDetailRepository GSTPaidDetails { get; }
        IMultimediaTypeRepository MultimediaTypes { get; }
        IPaymentTypeRepository PaymentTypes { get; }
        IServiceCategoryRepository ServiceCategories { get; }
        IStatusRepository Statuses { get; }
        IUserLoggedActivityRepository UserLoggedActivities { get; }
        IServiceChargeUpdateHistoryRepository ServiceChargeUpdateHistories { get; }

        Task CompleteAsync();
    }
}
