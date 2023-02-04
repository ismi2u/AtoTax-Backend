using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;

namespace AtoTax.API.Repository.Repos
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {

        private readonly AtoTaxDbContext _context;
        public StatusRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }
    }
}
