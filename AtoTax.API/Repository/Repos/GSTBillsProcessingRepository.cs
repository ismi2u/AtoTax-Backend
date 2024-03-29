﻿using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AtoTax.API.Repository.Repos
{
    public class GSTBillsProcessingRepository : Repository<GSTBillsProcessing>, IGSTBillsProcessingRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly ILogger<GSTBillsProcessing> _logger;
        public GSTBillsProcessingRepository(AtoTaxDbContext context, ILogger<GSTBillsProcessing> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }


        public async Task<GSTBillsProcessing> UpdateAsync(GSTBillsProcessing entity)
        {
           // entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();

            return entity;
        }
    }
}
