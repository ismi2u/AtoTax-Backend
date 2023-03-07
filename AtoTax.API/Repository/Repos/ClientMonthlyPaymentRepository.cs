using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtoTax.API.Repository.Repos
{
    public class ClientMonthlyPaymentRepository : Repository<ClientMonthlyPayment>, IClientMonthlyPaymentRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ClientMonthlyPayment> _logger;
        public ClientMonthlyPaymentRepository(AtoTaxDbContext context, ILogger<ClientMonthlyPayment> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


    }
}
