using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AtoTax.API.Repository.Repos
{
    public class MonthYearRepository : IMonthYearRepository
    {
        private readonly AtoTaxDbContext _context;
        internal DbSet<MonthYear> dbSet;
        private readonly new ILogger<MonthYear> _logger;
        private AtoTaxDbContext context;


        public MonthYearRepository(AtoTaxDbContext context, ILogger<MonthYear> logger)
        {

            _context = context;
            dbSet = _context.Set<MonthYear>();
            _logger = logger;
        }


        public async Task<List<MonthYear>> GetAllAsync(Expression<Func<MonthYear, bool>>? filter = null, params string[] allIncludeStrings)
        {

            IQueryable<MonthYear> query = dbSet;


            query = allIncludeStrings.Aggregate(query,
                     (current, include) => current.Include(include));


            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<MonthYear> GetAsync(Expression<Func<MonthYear, bool>> filter = null, bool tracked = true, params string[] allIncludeStrings)
        {
            IQueryable<MonthYear> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            query = allIncludeStrings.Aggregate(query,
                     (current, include) => current.Include(include));


            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(MonthYear entity)
        {
            IQueryable<MonthYear> query = dbSet;

            query = query.AsNoTracking(); // set to no tracking

            string strCurrentMonth = GetCurrentMonth();
            string strCurrentYear = GetCurrentYear();
           
            query = query.Where(q=> q.Month == strCurrentMonth && q.Year == strCurrentYear);
            if(query != null)
            {
                await dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

            }

           



        }
        public async Task RemoveAsync(MonthYear entity)
        {
            dbSet.Remove(entity);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public Task<MonthYear> UpdateAsync(MonthYear entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Current Month and Year
        /// </summary>
        /// <returns></returns>
        public string GetCurrentYear()
        {
            string CurrentYear = DateTime.Now.Year.ToString();

            return CurrentYear;
        }

        public string GetCurrentMonth()
        {
            string CurrentMonth = DateTime.Now.Month.ToString();

            return CurrentMonth;
        }
    }
}
