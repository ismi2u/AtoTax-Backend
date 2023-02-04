using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class ClientFeeChargeRepository : Repository<ClientFeeCharge>, IClientFeeChargeRepository
    {
        private readonly AtoTaxDbContext _context;
        public ClientFeeChargeRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<ClientFeeCharge> UpdateAsync(ClientFeeCharge entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
