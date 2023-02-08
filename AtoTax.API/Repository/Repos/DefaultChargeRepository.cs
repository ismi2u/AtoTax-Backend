using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class DefaultChargeRepository : Repository<DefaultCharge>, IDefaultChargeRepository
    {
        private readonly AtoTaxDbContext _context;
        public DefaultChargeRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<DefaultCharge> UpdateAsync(DefaultCharge entity)
        {

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
