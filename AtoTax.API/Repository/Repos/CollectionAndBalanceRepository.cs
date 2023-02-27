using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtoTax.API.Repository.Repos
{
    public class CollectionAndBalanceRepository : Repository<CollectionAndBalance>, ICollectionAndBalanceRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<CollectionAndBalance> _logger;
        public CollectionAndBalanceRepository(AtoTaxDbContext context, ILogger<CollectionAndBalance> logger) : base(context, logger)
        {

            _context = context;
            _logger = logger;
        }

        public async Task SyncDataAsync()
        {
            //For Each GST Client 
            //For EachMonth & For current year
            Console.WriteLine("CronJob Started at" + DateTime.Now.ToLocalTime());

            var listGSTClients = await _context.GSTClients.Where(c => c.StatusId == (int)EStatus.active).ToListAsync();

            var todayDate = DateTime.Now;
            string newMonth = todayDate.ToString("MMMM");
            int newMonthYear = todayDate.Year;


           var prevMonthDate = todayDate.AddMonths(-1);
            string prevMonth = prevMonthDate.ToString("MMMM");
            int prevMonthYear = prevMonthDate.Year;

            foreach (var client in listGSTClients)
            {
                bool ifRecordAlreadyPresent = _context.CollectionAndBalances.Where(c => c.GSTClientId == client.Id && c.DueMonth == newMonth && c.DueYear == newMonthYear).Any();

                if(ifRecordAlreadyPresent)
                {
                    continue;
                }
                CollectionAndBalance collectionAndBalance = new();
                // ServiceCategoryId == 1 refers to GST Monthly Submission category
                var clientFeeMap = _context.ClientFeeMaps.Where(c => c.GSTClientId == client.Id && c.ServiceCategoryId == 1).FirstOrDefault();

                collectionAndBalance.GSTClientId = client.Id;
                collectionAndBalance.DueMonth = newMonth;
                collectionAndBalance.DueYear = newMonthYear;
                collectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                collectionAndBalance.AmountPaid = 0;
                collectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;

                _context.CollectionAndBalances.Add(collectionAndBalance);
            }

            //
            //background job send sms
            //BackgroundJob.Enqueue<Iservice>(x => x.sendsms());

            await _context.SaveChangesAsync();
            Console.WriteLine("CronJob Started at" + DateTime.Now.ToLocalTime());
        }

        public async Task<CollectionAndBalance> UpdateAsync(CollectionAndBalance entity)
        {
            //entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
           // await _context.SaveChangesAsync();
            _logger.LogInformation("CollectionAndBalance Id" + entity.Id.ToString() + " updated");

            return entity;
        }

       
    }
}
