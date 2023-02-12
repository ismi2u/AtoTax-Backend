using AtoTax.API.Controllers;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.Repository.Repos;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace AtoTax.API.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAddressTypeRepository AddressTypes { get; private set; }
        public IAmendmentRepository Amendments { get; private set; }
        public IAmendTypeRepository AmendTypes { get; private set; }
        public IClientFeeMapRepository ClientFeeMaps { get; private set; }
        public IEmpJobRoleRepository EmpJobRoles { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        public ICollectionAndBalanceRepository CollectionAndBalances { get; private set; }
        public IGSTBillAndFeeCollectionRepository GSTBillAndFeeCollections { get; private set; }
        public IGSTClientAddressExtensionRepository GSTClientAddressExtensions { get; private set; }
        public IFeeCollectionLedgerRepository FeeCollectionLedgers { get; private set; }
        public IGSTClientRepository GSTClients { get; private set; }
        public IGSTFilingTypeRepository GSTFilingTypes { get; private set; }
        public IGSTPaidDetailRepository GSTPaidDetails { get; private set; }
        public IMultimediaTypeRepository MultimediaTypes { get; private set; }
        public IPaymentTypeRepository PaymentTypes { get; private set; }
        public IServiceCategoryRepository ServiceCategories { get; private set; }
        public IStatusRepository Statuses { get; private set; }
        public IUserLoggedActivityRepository UserLoggedActivities { get; private set; }
        public IServiceChargeUpdateHistoryRepository ServiceChargeUpdateHistories { get; private set; }



        private readonly AtoTaxDbContext _context;

        private readonly ILogger<AddressType> _AddressTypeLogger;
        private readonly ILogger<Amendment> _AmendmentLogger;
        private readonly ILogger<AmendType> _AmendTypeLogger;
        private readonly ILogger<ClientFeeMap> _ClientFeeMapLogger;
        private readonly ILogger<EmpJobRole> _EmpJobRoleLogger;
        private readonly ILogger<Employee> _EmployeeLogger;
        private readonly ILogger<CollectionAndBalance> _CollectionAndBalanceLogger;
        private readonly ILogger<GSTBillAndFeeCollection> _GSTBillAndFeeCollectionLogger;
        private readonly ILogger<GSTClientAddressExtension> _GSTClientAddressExtensionLogger;
        private readonly ILogger<FeeCollectionLedger> _FeeCollectionLedgerLogger;
        private readonly ILogger<GSTClient> _GSTClientLogger;
        private readonly ILogger<GSTFilingType> _GSTFilingTypeLogger;
        private readonly ILogger<GSTPaidDetail> _GSTPaidDetailLogger;
        private readonly ILogger<MultimediaType> _MultimediaTypeLogger;
        private readonly ILogger<PaymentType> _PaymentTypeLogger;
        private readonly ILogger<ServiceCategory> _ServiceCategoryLogger;
        private readonly ILogger<Status> _StatusLogger;
        private readonly ILogger<UserLoggedActivity> _UserLoggedActivityLogger;
        private readonly ILogger<ServiceChargeUpdateHistory> _ServiceChargeUpdateHistoryLogger;

        public UnitOfWork(AtoTaxDbContext context,

            ILogger<AddressType> AddressTypeLogger,
             ILogger<Amendment> AmendmentLogger,
             ILogger<AmendType> AmendTypeLogger,
            ILogger<ClientFeeMap> ClientFeeMapLogger,
            ILogger<EmpJobRole> EmpJobRoleLogger,
            ILogger<Employee> EmployeeLogger,
            ILogger<CollectionAndBalance> CollectionAndBalanceLogger,
            ILogger<GSTBillAndFeeCollection> GSTBillAndFeeCollectionLogger,
            ILogger<GSTClientAddressExtension> GSTClientAddressExtensionLogger,
            ILogger<FeeCollectionLedger> FeeCollectionLedgerLogger,
            ILogger<GSTClient> GSTClientLogger,
            ILogger<GSTFilingType> GSTFilingTypeLogger,
            ILogger<GSTPaidDetail> GSTPaidDetailLogger,
            ILogger<MultimediaType> MultimediaTypeLogger,
            ILogger<PaymentType> PaymentTypeLogger,
            ILogger<ServiceCategory> ServiceCategoryLogger,
            ILogger<Status> StatusLogger,
            ILogger<UserLoggedActivity> UserLoggedActivityLogger,
            ILogger<ServiceChargeUpdateHistory> ServiceChargeUpdateHistoryLogger

            )
        {
            _context = context;

            _AddressTypeLogger = AddressTypeLogger;
            _AmendmentLogger = AmendmentLogger;
            _AmendTypeLogger = AmendTypeLogger;
            _ClientFeeMapLogger = ClientFeeMapLogger;
            _EmpJobRoleLogger = EmpJobRoleLogger;
            _EmployeeLogger = EmployeeLogger;
            _CollectionAndBalanceLogger= CollectionAndBalanceLogger;
            _GSTBillAndFeeCollectionLogger = GSTBillAndFeeCollectionLogger;
            _GSTClientAddressExtensionLogger= GSTClientAddressExtensionLogger;
            _FeeCollectionLedgerLogger= FeeCollectionLedgerLogger;
            _GSTClientLogger = GSTClientLogger;
            _GSTFilingTypeLogger=   GSTFilingTypeLogger;
            _GSTPaidDetailLogger= GSTPaidDetailLogger;
            _MultimediaTypeLogger = MultimediaTypeLogger;
            _PaymentTypeLogger= PaymentTypeLogger;
            _StatusLogger= StatusLogger;
            _ServiceCategoryLogger = ServiceCategoryLogger;
            _UserLoggedActivityLogger= UserLoggedActivityLogger;
            _ServiceChargeUpdateHistoryLogger= ServiceChargeUpdateHistoryLogger;

            AddressTypes = new AddressTypeRepository(_context, _AddressTypeLogger);
            Amendments = new AmendmentRepository(_context, _AmendmentLogger);
            AmendTypes = new AmendTypeRepository(_context, _AmendTypeLogger);
            ClientFeeMaps = new ClientFeeMapRepository(_context, _ClientFeeMapLogger);
            EmpJobRoles = new EmpJobRoleRepository(_context, _EmpJobRoleLogger);
            Employees = new EmployeeRepository(_context, _EmployeeLogger);
            CollectionAndBalances = new CollectionAndBalanceRepository(_context, _CollectionAndBalanceLogger);
            GSTBillAndFeeCollections = new GSTBillAndFeeCollectionRepository(_context, _GSTBillAndFeeCollectionLogger);
            GSTClientAddressExtensions = new GSTClientAddressExtensionRepository(_context, _GSTClientAddressExtensionLogger);
            FeeCollectionLedgers = new FeeCollectionLedgerRepository(_context, _FeeCollectionLedgerLogger);
            GSTClients = new GSTClientRepository(_context, _GSTClientLogger);
            GSTFilingTypes = new GSTFilingTypeRepository(_context, _GSTFilingTypeLogger);
            GSTPaidDetails = new GSTPaidDetailRepository(_context, _GSTPaidDetailLogger);
            MultimediaTypes = new MultimediaTypeRepository(_context, _MultimediaTypeLogger);
            PaymentTypes = new PaymentTypeRepository(_context, _PaymentTypeLogger);
            ServiceCategories = new ServiceCategoryRepository(_context, _ServiceCategoryLogger);
            Statuses = new StatusRepository(_context, _StatusLogger);
            UserLoggedActivities = new UserLoggedActivityRepository(_context, _UserLoggedActivityLogger);
            ServiceChargeUpdateHistories = new ServiceChargeUpdateHistoryRepository(_context, _ServiceChargeUpdateHistoryLogger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
