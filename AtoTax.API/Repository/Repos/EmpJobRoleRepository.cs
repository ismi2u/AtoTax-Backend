using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class EmpJobRoleRepository : Repository<EmpJobRole>, IEmpJobRoleRepository
    {
        private readonly AtoTaxDbContext _context;
        public EmpJobRoleRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


        public async Task<EmpJobRole> UpdateAsync(EmpJobRole entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
