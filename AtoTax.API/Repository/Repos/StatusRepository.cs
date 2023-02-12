using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;

namespace AtoTax.API.Repository.Repos
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {

        private readonly AtoTaxDbContext _context;
        private readonly ILogger<Status> _logger;
        public StatusRepository(AtoTaxDbContext context, ILogger<Status> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }
    }
}
