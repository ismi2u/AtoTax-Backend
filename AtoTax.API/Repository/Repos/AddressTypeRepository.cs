using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AddressTypeRepository : Repository<AddressType>, IAddressTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<AddressType> _logger;
        private AtoTaxDbContext context;


        public AddressTypeRepository(AtoTaxDbContext context, ILogger<AddressType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<AddressType> UpdateAsync(AddressType entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
