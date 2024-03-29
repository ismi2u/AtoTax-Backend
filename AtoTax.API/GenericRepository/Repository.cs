﻿using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace AtoTax.API.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AtoTaxDbContext _context;
        internal DbSet<T> dbSet;
        protected readonly ILogger<T> _logger;

        public Repository(AtoTaxDbContext context, ILogger<T> logger)
        {
            _context = context;
            dbSet = _context.Set<T>();
            _logger = logger;
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pagesize = 3, int pagenumber = 1, params string[] allIncludeStrings)
        {

            IQueryable<T> query = dbSet;


            query = allIncludeStrings.Aggregate(query,
                     (current, include) => current.Include(include));


            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pagesize > 0)
            {
                if (pagesize > 50)
                {
                    pagesize = 50;
                }
                //skip(0). take (5)
                
                query = query.Skip(pagesize * (pagenumber - 1)).Take(pagesize);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, params string[] allIncludeStrings)
        {
            IQueryable<T> query = dbSet;
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

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            
        }

        public async Task SaveAsync()
        {
           // await _context.SaveChangesAsync();
        }


    }
}
