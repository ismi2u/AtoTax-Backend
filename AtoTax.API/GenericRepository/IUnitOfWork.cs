using AtoTax.API.Repository.Interfaces;

namespace AtoTax.API.GenericRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IAddressTypeRepository AddressTypes { get; }
        IAmendmentRepository Amendments { get; }
        IAmendTypeRepository AmendTypes { get; }

        IClientFeeMapRepository ClientFeeMaps { get; }
        IDefaultChargeRepository DefaultCharges { get; }
        IEmpJobRoleRepository EmpJobRoles { get; }
        IEmployeeRepository Employees { get; }
        IGSTBillAndFeeCollectionRepository GSTBillAndFeeCollections { get; }
        IGSTClientAddressExtensionRepository GSTClientAddressExtensions { get; }
        IGSTClientRepository GSTClients { get; }

        IGSTFilingTypeRepository GSTFilingTypes { get; }
        IGSTPaidDetailRepository GSTPaidDetails { get; }
        IMultimediaTypeRepository MultimediaTypes { get; }
        IPaymentTypeRepository PaymentTypes { get; }
        IServiceCategoryRepository ServiceCategories { get; }
        IStatusRepository Statuses { get; }
        IUserLoggedActivityRepository UserLoggedActivities { get; }

        Task CompleteAsync();
    }
}
