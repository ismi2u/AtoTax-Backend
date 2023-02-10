
using AtoTax.Domain.Entities;
using AtoTaxAPI.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        }

        public DbSet<Status> Status { get; set; }
        public DbSet<GSTClient> GSTClients { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<ClientFeeCharge> ClientFeeCharges { get; set; }
        public DbSet<EmpJobRole> EmpJobRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GSTFilingType> GSTFilingTypes { get; set; }

        public DbSet<DefaultCharge> DefaultCharges { get; set; }

        public DbSet<GSTPaidDetail> GSTPaidDetails { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<GSTClientAddressExtension> GSTClientAddressExtensions { get; set; }

        public DbSet<AmendType> AmendTypes { get; set; }
        public DbSet<Amendment> Amendments { get; set; }



        public DbSet<GSTBillAndFeeCollection> GSTBillAndFeeCollections { get; set; }
       
        public DbSet<ServiceChargeUpdateHistory> ServiceChargeUpdateHistory { get; set; }
       


    }
}
