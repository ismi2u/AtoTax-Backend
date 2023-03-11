using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class FrequencyRepository : Repository<Frequency>, IFrequencyRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<Frequency> _logger;
        public FrequencyRepository(AtoTaxDbContext context, ILogger<Frequency> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }

      

    }
}
