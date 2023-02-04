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
        public UserLoggedActivityRepository(AtoTaxDbContext context) : base(context)
        {

            _context = context;
        }


       
    }
}
