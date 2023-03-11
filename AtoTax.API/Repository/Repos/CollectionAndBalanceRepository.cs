using AtoTax.API.GenericRepository;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Ocsp;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task SyncMonthlyDataAsync()
        {
            Console.WriteLine("Monthly Sync CronJob Started at " + DateTime.Now.ToLocalTime());


            var todayDate = DateTime.Now;
            string todayMonth = todayDate.ToString("MM");
            int todayYear = todayDate.Year;

            var listGSTClients = await _context.GSTClients
                                        .Where(c => c.StatusId == (int)EStatus.active
                                        && c.isRegular == true).ToListAsync();

            foreach (var client in listGSTClients)
            {
                CollectionAndBalance collectionAndBalance = new();
                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.FrequencyId == (int)EFrequency.MonthlyReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {

                    var listReturnFrequencies = _context.Frequencies.ToList();

                    foreach (var returnFrequency in listReturnFrequencies)
                    {

                        if (returnFrequency.Id != (int)EFrequency.MonthlyReturn)
                        {
                            continue;
                        }
                        var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthIdx == todayMonth 
                        && m.Year == todayYear).FirstOrDefault();


                        //query = query.AsNoTracking();
                        var existCollectionAndBal = _context.CollectionAndBalances.Where(c => c.GSTClientId == client.Id &&
                                            c.FrequencyId == (int)EFrequency.MonthlyReturn &&
                                            c.DueMonth == MonthAndYear.MonthYear &&
                                            c.DueYear == MonthAndYear.Year).Any();

                        if (existCollectionAndBal)
                        {
                            continue;
                        }
                        else
                        {
                            if (returnFrequency.Id == (int)EFrequency.MonthlyReturn)
                            {
                                collectionAndBalance.GSTClientId = client.Id;
                                collectionAndBalance.FrequencyId = (int)EFrequency.MonthlyReturn;
                                collectionAndBalance.DueMonth = MonthAndYear.MonthYear;
                                collectionAndBalance.DueYear = MonthAndYear.Year;
                                collectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                                collectionAndBalance.AmountPaid = 0;
                                collectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;

                                await dbSet.AddAsync(collectionAndBalance);
                                await _context.SaveChangesAsync();

                            }
                        }

                       
                    }
                }
            }

         
            Console.WriteLine("Monthly Sync CronJob Completed at " + DateTime.Now.ToLocalTime());
        }


        public async Task SyncAnnualDataAsync()
        {
            Console.WriteLine("Annual Sync CronJob Started at " + DateTime.Now.ToLocalTime());

            var listGSTClients = await _context.GSTClients.Where(c => c.StatusId == (int)EStatus.active).ToListAsync();

            var todayDate = DateTime.Now;
            string todayMonth = todayDate.ToString("MM");
            int todayYear = todayDate.Year;

            IQueryable<CollectionAndBalance> query = dbSet;

            foreach (var client in listGSTClients)
            {

                CollectionAndBalance collectionAndBalance = new();
                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.FrequencyId == (int)EFrequency.AnnualReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {

                    var listReturnFrequencies = _context.Frequencies.ToList();

                    foreach (var returnFrequency in listReturnFrequencies)
                    {

                        if (returnFrequency.Id != (int)EFrequency.AnnualReturn)
                        {
                            continue;
                        }
                        var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthIdx == todayMonth && m.Year == todayYear).FirstOrDefault();


                        var existCollectionAndBal = _context.CollectionAndBalances.Where(c => c.GSTClientId == client.Id &&
                                            c.FrequencyId == (int)EFrequency.AnnualReturn &&
                                            c.DueYear == MonthAndYear.Year).Any();

                        if (existCollectionAndBal)
                        {
                            continue;
                        }

                      

                        if (returnFrequency.Id == (int)EFrequency.AnnualReturn)
                        {
                            collectionAndBalance.GSTClientId = client.Id;
                            collectionAndBalance.FrequencyId = (int)EFrequency.AnnualReturn;
                            collectionAndBalance.DueMonth = null;
                            collectionAndBalance.DueYear = MonthAndYear.Year;
                            collectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                            collectionAndBalance.AmountPaid = 0;
                            collectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;
                            await _context.CollectionAndBalances.AddAsync(collectionAndBalance);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }

            //
            //background job send sms
            //BackgroundJob.Enqueue<Iservice>(x => x.sendsms());

        
            Console.WriteLine("Annual Sync CronJob Completed at " + DateTime.Now.ToLocalTime());
        }

        public async Task SyncQuaterlyDataAsync()
        {
            Console.WriteLine("Annual Sync CronJob Started at " + DateTime.Now.ToLocalTime());

            var listGSTClients = await _context.GSTClients.Where(c => c.StatusId == (int)EStatus.active
                               && c.isRegular == false).ToListAsync(); //Non-Regular Client

            var todayDate = DateTime.Now;
            string todayMonth = todayDate.ToString("MM"); //03
            int todayYear = todayDate.Year;

            foreach (var client in listGSTClients)
            {


                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.FrequencyId == (int)EFrequency.QuaterlyReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {

                    var listReturnFrequencies = _context.Frequencies.ToList();

                    foreach (var returnFrequency in listReturnFrequencies)
                    {

                        if (returnFrequency.Id != (int)EFrequency.QuaterlyReturn)
                        {
                            continue;
                        }

                        if (returnFrequency.Id == (int)EFrequency.QuaterlyReturn)
                        {
                            for (int i = 3; i <= 12; i += 3)
                            {

                                string monthNameFull = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "-" + todayYear.ToString();
                                //var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthYear == monthNameFull.Substring(0, 3) + "-" + todayYear).FirstOrDefault();
                                var existCollandBal = _context.CollectionAndBalances.Where(c => c.GSTClientId == client.Id
                                                                       && c.FrequencyId == (int)EFrequency.QuaterlyReturn
                                                                      && c.DueMonth == monthNameFull
                                                                      && c.DueYear == todayYear).Any();

                                if(existCollandBal)
                                {
                                    continue;
                                }
                                else
                                {
                                    CollectionAndBalance collectionAndBalance = new();

                                    collectionAndBalance.GSTClientId = client.Id;
                                    collectionAndBalance.FrequencyId = (int)EFrequency.QuaterlyReturn;
                                    collectionAndBalance.DueMonth = monthNameFull;
                                    collectionAndBalance.DueYear = todayYear;
                                    collectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                                    collectionAndBalance.AmountPaid = 0;
                                    collectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;

                                    _context.CollectionAndBalances.Add(collectionAndBalance);

                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Quaterly Sync CronJob Completed at " + DateTime.Now.ToLocalTime());
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
