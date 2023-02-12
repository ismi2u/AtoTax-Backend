
using AtoTax.Domain.Entities;
using AtoTaxAPI.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AtoTaxAPI.Data
{
    public class AtoTaxDbContext : IdentityDbContext<ApplicationUser>
    {

        public AtoTaxDbContext(DbContextOptions<AtoTaxDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);


            builder.Entity<Status>().HasData(
             new Status { Id = 1, StatusType = "active" },
             new Status { Id = 2, StatusType = "inactive" }
             );

           

            builder.Entity<GSTClient>().HasData(
             new GSTClient { Id = new Guid( "ebf7cf6d-26fa-40a7-90ab-b86402a7e594"),
                 ProprietorName = "Rexona Co",
                 GSTIN = "123456789",
                 ContactName = "Raja Mohamed",
                 GSTUserName = "gstusername",
                 GSTUserPassword = "GSTUserPassword",
                 GSTRegDate = DateTime.UtcNow,
                 GSTSurrenderedDate = null,
                 GSTRelievedDate = null,
                 GSTAnnualTurnOver = 10000,
                 MobileNumber = "829733325",
                 PhoneNumber = "829733325",
                 ContactEmailId = "test@test.com",
                 GSTEmailId = "test1@test.com",
                 GSTEmailPassword = "testerpass",
                 GSTRecoveryEmailId = "recover@test.com",
                 GSTRecoveryEmailPassword = "GSTRecoveryEmailPassword",
                 EWAYBillUserName = "EWAYBillUserName",
                 EWAYBillPassword = "EWAYBillPassword",
                 RackFileNo = "RackFileNo",
                 TallyDataFilePath = @"F:\\userfolder\txt1.txt",
                 CreatedDate = DateTime.UtcNow,
                 LastModifiedDate = DateTime.UtcNow,
                 StatusId = 1 }           
             );

            builder.Entity<ServiceCategory>().HasData(
             new ServiceCategory { Id = 1, ServiceName = "GSTMonthlySubmission", DefaultCharge=1000, PreviousCharge=1000, Description = "GST Monthly Submission", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
             new ServiceCategory { Id = 2, ServiceName = "GSTAmendment", DefaultCharge = 2000, PreviousCharge=2000, Description = "GST Amendment", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new ServiceCategory { Id = 3, ServiceName = "GSTAnnualReturnFiling", DefaultCharge = 500, PreviousCharge = 500, Description = "GST Annual Return Filing", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
             new ServiceCategory { Id = 4, ServiceName = "GSTNoticeService", DefaultCharge = 200, PreviousCharge=200, Description = "GST Notice Service", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
             );


        }

        public DbSet<Status> Status { get; set; }
        public DbSet<GSTClient> GSTClients { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<MultimediaType> MultimediaTypes { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ClientFeeMap> ClientFeeMaps { get; set; }
        public DbSet<EmpJobRole> EmpJobRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GSTFilingType> GSTFilingTypes { get; set; }

        public DbSet<GSTPaidDetail> GSTPaidDetails { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<GSTClientAddressExtension> GSTClientAddressExtensions { get; set; }

        public DbSet<AmendType> AmendTypes { get; set; }
        public DbSet<Amendment> Amendments { get; set; }

        public DbSet<CollectionAndBalance> CollectionAndBalances { get; set; }
        public DbSet<FeeCollectionLedger> FeeCollectionLedgers { get; set; }

        public DbSet<ServiceChargeUpdateHistory> ServiceChargeUpdateHistories { get; set; }

        public DbSet<GSTBillAndFeeCollection> GSTBillAndFeeCollections { get; set; }
       
        public DbSet<ServiceChargeUpdateHistory> ServiceChargeUpdateHistory { get; set; }

        public DbSet<UserLoggedActivity> UserLoggedActivities { get; set; }



    }
}
