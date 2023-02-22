using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class ApprovalStatusTypeRepository : Repository<ApprovalStatusType>, IApprovalStatusTypeRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ApprovalStatusType> _logger;
        private AtoTaxDbContext context;


        public ApprovalStatusTypeRepository(AtoTaxDbContext context, ILogger<ApprovalStatusType> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


    }
}
