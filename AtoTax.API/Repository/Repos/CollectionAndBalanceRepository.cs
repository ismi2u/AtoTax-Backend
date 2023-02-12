using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtoTax.API.Repository.Repos
{
    public class CollectionAndBalanceRepository : Repository<CollectionAndBalance>, ICollectionAndBalanceRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<CollectionAndBalance> _logger;
        public CollectionAndBalanceRepository(AtoTaxDbContext context, ILogger<CollectionAndBalance> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<CollectionAndBalance> UpdateAsync(CollectionAndBalance entity)
        {
            //entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("CollectionAndBalance Id" + entity.Id.ToString() + " updated");

            return entity;
        }

       
    }
}
