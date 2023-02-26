using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTPaidDetailRepository : Repository<GSTPaidDetail>, IGSTPaidDetailRepository
    {
        private readonly AtoTaxDbContext _context;
        //private readonly ILogger<GSTPaidDetail> _logger;
        public GSTPaidDetailRepository(AtoTaxDbContext context, ILogger<GSTPaidDetail> logger) : base(context, logger)
        {

            _context = context;
            //_logger = logger;
        }


        public async Task<GSTPaidDetail> UpdateAsync(GSTPaidDetail entity)
        {
            //entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
