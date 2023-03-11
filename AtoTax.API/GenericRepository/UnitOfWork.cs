using AtoTax.API.Controllers;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.Repository.Repos;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Linq.Expressions;

namespace AtoTax.API.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        public IAddressTypeRepository AddressTypes { get; private set; }
        public IFrequencyRepository Frequencies { get; private set; }
        public IAmendmentRepository Amendments { get; private set; }
        public IAmendTypeRepository AmendTypes { get; private set; }
        public IClientFeeMapRepository ClientFeeMaps { get; private set; }
        public ICollectionAndBalanceRepository CollectionAndBalances { get; private set; }
        public IGSTBillsProcessingRepository GSTBillsProcessings { get; private set; }
        public IGSTClientAddressExtensionRepository GSTClientAddressExtensions { get; private set; }
        public IAccountLedgerRepository AccountLedgers { get; private set; }
        public IGSTClientRepository GSTClients { get; private set; }
        public IGSTFilingTypeRepository GSTFilingTypes { get; private set; }
        public IGSTPaidDetailRepository GSTPaidDetails { get; private set; }
        public IMultimediaTypeRepository MultimediaTypes { get; private set; }
        public IPaymentTypeRepository PaymentTypes { get; private set; }
        public IServiceCategoryRepository ServiceCategories { get; private set; }
        public IStatusRepository Statuses { get; private set; }
        public IUserLoggedActivityRepository UserLoggedActivities { get; private set; }
        public IServiceChargeUpdateHistoryRepository ServiceChargeUpdateHistories { get; private set; }

        public IClientMonthlyPaymentRepository ClientMonthlyPayments { get; private set; }

        private readonly AtoTaxDbContext _context;
        private readonly ILogger<Frequency> _FrequencyLogger;
        private readonly ILogger<AddressType> _AddressTypeLogger;
        private readonly ILogger<Amendment> _AmendmentLogger;
        private readonly ILogger<AmendType> _AmendTypeLogger;
        private readonly ILogger<ClientFeeMap> _ClientFeeMapLogger;
        private readonly ILogger<CollectionAndBalance> _CollectionAndBalanceLogger;
        private readonly ILogger<GSTBillsProcessing> _GSTBillsProcessingLogger;
        private readonly ILogger<GSTClientAddressExtension> _GSTClientAddressExtensionLogger;
        private readonly ILogger<AccountLedger> _AccountLedgerLogger;
        private readonly ILogger<GSTClient> _GSTClientLogger;
        private readonly ILogger<GSTFilingType> _GSTFilingTypeLogger;
        private readonly ILogger<GSTPaidDetail> _GSTPaidDetailLogger;
        private readonly ILogger<MultimediaType> _MultimediaTypeLogger;
        private readonly ILogger<PaymentType> _PaymentTypeLogger;
        private readonly ILogger<ServiceCategory> _ServiceCategoryLogger;
        private readonly ILogger<Status> _StatusLogger;
        private readonly ILogger<UserLoggedActivity> _UserLoggedActivityLogger;
        private readonly ILogger<ServiceChargeUpdateHistory> _ServiceChargeUpdateHistoryLogger;
        private readonly ILogger<ClientMonthlyPayment> _ClientMonthlyPaymentLogger;

        public UnitOfWork(AtoTaxDbContext context,

            ILogger<Frequency> FrequencyLogger,
            ILogger<AddressType> AddressTypeLogger,
             ILogger<Amendment> AmendmentLogger,
             ILogger<AmendType> AmendTypeLogger,
            ILogger<ClientFeeMap> ClientFeeMapLogger,
            ILogger<CollectionAndBalance> CollectionAndBalanceLogger,
            ILogger<GSTBillsProcessing> GSTBillsProcessingLogger,
            ILogger<GSTClientAddressExtension> GSTClientAddressExtensionLogger,
            ILogger<AccountLedger> AccountLedgerLogger,
            ILogger<GSTClient> GSTClientLogger,
            ILogger<GSTFilingType> GSTFilingTypeLogger,
            ILogger<GSTPaidDetail> GSTPaidDetailLogger,
            ILogger<MultimediaType> MultimediaTypeLogger,
            ILogger<PaymentType> PaymentTypeLogger,
            ILogger<ServiceCategory> ServiceCategoryLogger,
            ILogger<Status> StatusLogger,
            ILogger<UserLoggedActivity> UserLoggedActivityLogger,
            ILogger<ServiceChargeUpdateHistory> ServiceChargeUpdateHistoryLogger,
            ILogger<ClientMonthlyPayment> ClientMonthlyPaymentLogger

            )
        {
            _context = context;

            _FrequencyLogger = FrequencyLogger;
            _AddressTypeLogger = AddressTypeLogger;
            _AmendmentLogger = AmendmentLogger;
            _AmendTypeLogger = AmendTypeLogger;
            _ClientFeeMapLogger = ClientFeeMapLogger;
            _CollectionAndBalanceLogger = CollectionAndBalanceLogger;
            _GSTBillsProcessingLogger = GSTBillsProcessingLogger;
            _GSTClientAddressExtensionLogger = GSTClientAddressExtensionLogger;
            _AccountLedgerLogger = AccountLedgerLogger;
            _GSTClientLogger = GSTClientLogger;
            _GSTFilingTypeLogger = GSTFilingTypeLogger;
            _GSTPaidDetailLogger = GSTPaidDetailLogger;
            _MultimediaTypeLogger = MultimediaTypeLogger;
            _PaymentTypeLogger = PaymentTypeLogger;
            _StatusLogger = StatusLogger;
            _ServiceCategoryLogger = ServiceCategoryLogger;
            _UserLoggedActivityLogger = UserLoggedActivityLogger;
            _ServiceChargeUpdateHistoryLogger = ServiceChargeUpdateHistoryLogger;
            _ClientMonthlyPaymentLogger= ClientMonthlyPaymentLogger;

            Frequencies = new FrequencyRepository(_context, _FrequencyLogger);
            AddressTypes = new AddressTypeRepository(_context, _AddressTypeLogger);
            Amendments = new AmendmentRepository(_context, _AmendmentLogger);
            AmendTypes = new AmendTypeRepository(_context, _AmendTypeLogger);
            ClientFeeMaps = new ClientFeeMapRepository(_context, _ClientFeeMapLogger);
            CollectionAndBalances = new CollectionAndBalanceRepository(_context, _CollectionAndBalanceLogger);
            GSTBillsProcessings = new GSTBillsProcessingRepository(_context, _GSTBillsProcessingLogger);
            GSTClientAddressExtensions = new GSTClientAddressExtensionRepository(_context, _GSTClientAddressExtensionLogger);
            AccountLedgers = new AccountLedgerRepository(_context, _AccountLedgerLogger);
            GSTClients = new GSTClientRepository(_context, _GSTClientLogger);
            GSTFilingTypes = new GSTFilingTypeRepository(_context, _GSTFilingTypeLogger);
            GSTPaidDetails = new GSTPaidDetailRepository(_context, _GSTPaidDetailLogger);
            MultimediaTypes = new MultimediaTypeRepository(_context, _MultimediaTypeLogger);
            PaymentTypes = new PaymentTypeRepository(_context, _PaymentTypeLogger);
            ServiceCategories = new ServiceCategoryRepository(_context, _ServiceCategoryLogger);
            Statuses = new StatusRepository(_context, _StatusLogger);
            UserLoggedActivities = new UserLoggedActivityRepository(_context, _UserLoggedActivityLogger);
            ServiceChargeUpdateHistories = new ServiceChargeUpdateHistoryRepository(_context, _ServiceChargeUpdateHistoryLogger);
            ClientMonthlyPayments = new ClientMonthlyPaymentRepository(_context, _ClientMonthlyPaymentLogger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();

            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
