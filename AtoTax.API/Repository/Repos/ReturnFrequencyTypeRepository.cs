using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class ReturnFrequencyTypeRepository : Repository<ReturnFrequencyType>, IReturnFrequencyTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ReturnFrequencyType> _logger;
        public ReturnFrequencyTypeRepository(AtoTaxDbContext context, ILogger<ReturnFrequencyType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }

      

    }
}
