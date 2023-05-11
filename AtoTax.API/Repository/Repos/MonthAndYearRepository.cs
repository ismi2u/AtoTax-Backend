using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

namespace AtoTax.API.Repository.Repos
{
    public class MonthAndYearRepository : IMonthAndYearRepository
    {
        private readonly AtoTaxDbContext _context;
        internal DbSet<MonthAndYear> dbSet;
        private readonly new ILogger<MonthAndYear> _logger;
        private AtoTaxDbContext context;


        public MonthAndYearRepository(AtoTaxDbContext context, ILogger<MonthAndYear> logger)
        {

            _context = context;
            dbSet = _context.Set<MonthAndYear>();
            _logger = logger;
        }


        public async Task<List<MonthAndYear>> GetAllAsync(Expression<Func<MonthAndYear, bool>>? filter = null, params string[] allIncludeStrings)
        {

            IQueryable<MonthAndYear> query = dbSet;


            query = allIncludeStrings.Aggregate(query,
                     (current, include) => current.Include(include));


            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<MonthAndYear> GetAsync(Expression<Func<MonthAndYear, bool>> filter = null, bool tracked = true, params string[] allIncludeStrings)
        {
            IQueryable<MonthAndYear> query = dbSet;
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




        public async Task CreateMonthYearAsync(int month = 0, int year = 0)
        {
            MonthAndYear monthAndYear = new MonthAndYear();
            bool isValidInput = false;

            if ((month != 0 && month > 0) && (year != 0  && year > 0))
            {
                isValidInput = true;
            }
            Console.WriteLine("Month And Year Table Start " + DateTime.Now.ToLocalTime());

            if (isValidInput)
            {
                var strMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

                monthAndYear.MonthIdx = month.ToString("d2");
                monthAndYear.Month = strMonth.Substring(0, 3);
                  monthAndYear.MonthYear = strMonth.Substring(0, 3) + "-" + year.ToString();
                monthAndYear.Year = year;

                //int intmonth = DateTime.ParseExact(strMonth, "MMMM", CultureInfo.CurrentCulture).Month;
                if (int.Parse(monthAndYear.MonthIdx) <= 3)
                {
                    monthAndYear.FiscalYear = "FY " + (year - 1).ToString() + "-" + (year).ToString();
                }
                else
                {
                    monthAndYear.FiscalYear = "FY " + year.ToString() + "-" + (year + 1).ToString();
                }

            }
            else
            {
                monthAndYear.MonthIdx = DateTime.Now.ToString("MM");
                monthAndYear.Month = DateTime.Now.ToString("MMMM").Substring(0, 3);
                monthAndYear.MonthYear = DateTime.Now.ToString("MMMM").Substring(0, 3) + "-" + DateTime.Now.Year.ToString();
                monthAndYear.Year = DateTime.Now.Year;
                //DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month
                //int intmonth = DateTime.ParseExact(monthAndYear.Month, "MMMM", CultureInfo.CurrentCulture).Month;
                if (int.Parse(monthAndYear.MonthIdx) <= 3)
                {
                    monthAndYear.FiscalYear = "FY " + (monthAndYear.Year - 1).ToString() + "-" + (monthAndYear.Year).ToString();
                }
                else
                {
                    monthAndYear.FiscalYear = "FY " + monthAndYear.Year.ToString() + "-" + (monthAndYear.Year + 1).ToString();
                }

            }



            IQueryable<MonthAndYear> query = dbSet;
            query = query.AsTracking(); 
            query = query.Where(q => q.Month == monthAndYear.Month && q.Year == monthAndYear.Year);
            if (!query.Any())
            {
                await dbSet.AddAsync(monthAndYear);
                await _context.SaveChangesAsync();

            }

            Console.WriteLine("Month And Year Table Complete " + DateTime.Now.ToLocalTime());
        }



        public async Task RemoveAsync(MonthAndYear entity)
        {
            dbSet.Remove(entity);

        }




        public async Task SaveAsync()
        {
            // await _context.SaveChangesAsync();
        }
        public Task<MonthAndYear> UpdateAsync(MonthAndYear entity)
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
