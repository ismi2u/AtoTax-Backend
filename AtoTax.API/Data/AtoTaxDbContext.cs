
using AtoTax.API.Authentication;
using AtoTax.Domain.Entities;
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

           

            builder.Entity<AmendType>().HasData(
            new AmendType { Id = 1, AmendTypeName = "Core", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new AmendType { Id = 2, AmendTypeName = "Non-Core", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
            );

            builder.Entity<PaymentType>().HasData(
            new PaymentType { Id = 1,  PaymentMethod = "Cash", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new PaymentType { Id = 2, PaymentMethod = "Bank Transfer",  CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new PaymentType { Id = 3, PaymentMethod = "UPIPay", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new PaymentType { Id = 4, PaymentMethod = "GooglePay", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new PaymentType { Id = 5, PaymentMethod = "Bank Cheque", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new PaymentType { Id = 6, PaymentMethod = "PayTM", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
            );

            builder.Entity<GSTFilingType>().HasData(
            new GSTFilingType { Id = 1,  FilingType = "GSTR-1", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 2, FilingType = "GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 9, FilingType = "GSTR-9", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 10, FilingType = "GSTR-9C", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 11, FilingType = "GSTR-10", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 14, FilingType = "NILGSTR1", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new GSTFilingType { Id = 15, FilingType = "NIL3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
         
            );

            builder.Entity<MultimediaType>().HasData(
            new MultimediaType { Id = 1, Media = "HardCopy", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 2,  Media = "Email", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 3, Media = "WhatsApp", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 4, Media = "USB/Pen Drive", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 5, Media = "Courier", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 6, Media = "Cloud Drive", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new MultimediaType { Id = 7, Media = "Hard Disk", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
            );


            builder.Entity<ApprovalStatusType>().HasData(
            new ApprovalStatusType { Id = 1, StatusType = "Pending" },
            new ApprovalStatusType { Id = 2, StatusType = "Approved" },
            new ApprovalStatusType { Id = 3, StatusType = "Rejected" }
            );

            builder.Entity<AddressType>().HasData(
            new AddressType { Id = 1, AddressTypeName="Office Street Address", AddressTypeDesc="Postal Street address", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new AddressType { Id = 2, AddressTypeName = "Residential Address", AddressTypeDesc = "Residential Street address", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new AddressType { Id = 3, AddressTypeName = "Godown/Factory Address", AddressTypeDesc = "Godown/Factory Address", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new AddressType { Id = 4, AddressTypeName = "PostBox Address", AddressTypeDesc = "Postoffice Box Number", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
            );

            builder.Entity<ReturnFrequencyType>().HasData(
            new ReturnFrequencyType { Id = 1, ReturnFreqType = "Monthly-Return", FixedCharge = 500, PreviousCharge = 500, Description = "GSTR-1 & GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new ReturnFrequencyType { Id = 2, ReturnFreqType = "NilGSTR", FixedCharge = 300, PreviousCharge = 300, Description = "GSTR-1 & GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new ReturnFrequencyType { Id = 3, ReturnFreqType = "Quaterly-Return", FixedCharge = 1000, PreviousCharge = 1000, Description = "GSTR-1 & GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new ReturnFrequencyType { Id = 4, ReturnFreqType = "Annual-Return", FixedCharge = 1000, PreviousCharge = 1000, Description = "GSTR-1 & GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 },
            new ReturnFrequencyType { Id = 5, ReturnFreqType = "FinalReturn", FixedCharge = 500, PreviousCharge = 500, Description = "GSTR-1 & GSTR-3B", CreatedDate = DateTime.UtcNow, LastModifiedDate = DateTime.UtcNow, StatusId = 1 }
            );

        }
        public DbSet<ReturnFrequencyType> ReturnFrequencyTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApprovalStatusType> ApprovalStatusTypes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<GSTClient> GSTClients { get; set; }
        public DbSet<ClientMonthlyPayment> ClientMonthlyPayments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<MultimediaType> MultimediaTypes { get; set; }
        public DbSet<ReturnFrequencyType> ServiceCategories { get; set; }
        public DbSet<ClientFeeMap> ClientFeeMaps { get; set; }
        public DbSet<GSTFilingType> GSTFilingTypes { get; set; }

        public DbSet<GSTPaidDetail> GSTPaidDetails { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<GSTClientAddressExtension> GSTClientAddressExtensions { get; set; }

        public DbSet<AmendType> AmendTypes { get; set; }
        public DbSet<Amendment> Amendments { get; set; }

        public DbSet<MonthAndYear> MonthAndYears { get; set; }

        public DbSet<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalances { get; set; }
        public DbSet<AccountLedger> AccountLedgers { get; set; }

        public DbSet<ServiceChargeUpdateHistory> ServiceChargeUpdateHistories { get; set; }

        public DbSet<GSTBillsProcessing> GSTBillsProcessings { get; set; }
       
        public DbSet<UserLoggedActivity> UserLoggedActivities { get; set; }



    }
}
