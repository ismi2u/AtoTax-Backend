using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class AmendmentRepository : Repository<Amendment>, IAmendmentRepository
    {
        private readonly AtoTaxDbContext _context;
        public AmendmentRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


    }
}
