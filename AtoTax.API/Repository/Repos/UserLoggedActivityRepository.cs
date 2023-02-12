using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class UserLoggedActivityRepository : Repository<UserLoggedActivity>, IUserLoggedActivityRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<UserLoggedActivity> _logger;
        public UserLoggedActivityRepository(AtoTaxDbContext context, ILogger<UserLoggedActivity> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


       
    }
}
