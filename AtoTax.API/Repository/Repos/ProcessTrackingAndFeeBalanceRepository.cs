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
    public class ProcessTrackingAndFeeBalanceRepository : Repository<ProcessTrackingAndFeeBalance>, IProcessTrackingAndFeeBalanceRepository
    {
        private readonly AtoTaxDbContext _context;
        private readonly new ILogger<ProcessTrackingAndFeeBalance> _logger;
        public ProcessTrackingAndFeeBalanceRepository(AtoTaxDbContext context, ILogger<ProcessTrackingAndFeeBalance> logger) : base(context, logger)
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
                ProcessTrackingAndFeeBalance ProcessTrackingAndFeeBalance = new();
                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.ReturnFrequencyTypeId == (int)EFrequency.MonthlyReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {

                    var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthIdx == todayMonth
                    && m.Year == todayYear).FirstOrDefault();


                    //query = query.AsNoTracking();
                    var existCollectionAndBal = _context.ProcessTrackingAndFeeBalances.Where(c => c.GSTClientId == client.Id &&
                                        c.ReturnFrequencyTypeId == (int)EFrequency.MonthlyReturn &&
                                        c.DueMonth == MonthAndYear.MonthYear &&
                                        c.DueYear == MonthAndYear.Year).Any();

                    if (existCollectionAndBal)
                    {
                        continue;
                    }
                    else
                    {


                        GSTClient gstClient = _context.GSTClients.FirstOrDefault(g => g.Id == client.Id);

                        ProcessTrackingAndFeeBalance.GSTClientId = gstClient.Id;
                        ProcessTrackingAndFeeBalance.ReturnFrequencyTypeId = (int)EFrequency.MonthlyReturn;
                        ProcessTrackingAndFeeBalance.DueMonth = MonthAndYear.MonthYear;
                        ProcessTrackingAndFeeBalance.DueYear = MonthAndYear.Year;
                        ProcessTrackingAndFeeBalance.FiscalYear = MonthAndYear.FiscalYear;

                        ProcessTrackingAndFeeBalance.RackFileNo = gstClient.RackFileNo;
                        ProcessTrackingAndFeeBalance.SalesInvoice = null;
                        ProcessTrackingAndFeeBalance.SalesBillsNil = null;
                        ProcessTrackingAndFeeBalance.PurchaseInvoice = null;
                        ProcessTrackingAndFeeBalance.PurchaseNil = null;
                        ProcessTrackingAndFeeBalance.GSTTaxAmount = null;

                        ProcessTrackingAndFeeBalance.FeesAmount = clientFeeMap.DefaultCharge;
                        ProcessTrackingAndFeeBalance.AmountPaid = 0;
                        ProcessTrackingAndFeeBalance.CurrentBalance = clientFeeMap.DefaultCharge;



                        ProcessTrackingAndFeeBalance.ReceivedDate = null;

                        ProcessTrackingAndFeeBalance.SalesFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNotFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNilFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNilNotFiled = null;
                        ProcessTrackingAndFeeBalance.SalesFiledDate = null;

                        ProcessTrackingAndFeeBalance.GSTR3BFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNotFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNILFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNilNotFiled = null;

                        ProcessTrackingAndFeeBalance.GSTR3BFiledDate = null;


                        await dbSet.AddAsync(ProcessTrackingAndFeeBalance);
                        await _context.SaveChangesAsync();

                    }

                }
            }


            Console.WriteLine("Monthly Sync CronJob Completed at " + DateTime.Now.ToLocalTime());
        }


        public async Task SyncAnnualDataAsync()
        {
            Console.WriteLine("Annual Sync CronJob Started at " + DateTime.Now.ToLocalTime());


            var todayDate = DateTime.Now;
            string todayMonth = todayDate.ToString("MM");
            int todayYear = todayDate.Year;

            var listGSTClients = await _context.GSTClients
                                        .Where(c => c.StatusId == (int)EStatus.active).ToListAsync();

            foreach (var client in listGSTClients)
            {
                ProcessTrackingAndFeeBalance ProcessTrackingAndFeeBalance = new();
                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.ReturnFrequencyTypeId == (int)EFrequency.AnnualReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {


                    var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthIdx == todayMonth
                    && m.Year == todayYear).FirstOrDefault();


                    //query = query.AsNoTracking();
                    var existCollectionAndBal = _context.ProcessTrackingAndFeeBalances.Where(c => c.GSTClientId == client.Id &&
                                        c.ReturnFrequencyTypeId == (int)EFrequency.AnnualReturn).Any();

                    if (existCollectionAndBal)
                    {
                        continue;
                    }
                    else
                    {


                        GSTClient gstClient = _context.GSTClients.FirstOrDefault(g => g.Id == client.Id);

                        ProcessTrackingAndFeeBalance.GSTClientId = gstClient.Id;
                        ProcessTrackingAndFeeBalance.ReturnFrequencyTypeId = (int)EFrequency.AnnualReturn;
                        ProcessTrackingAndFeeBalance.DueMonth = null;
                        ProcessTrackingAndFeeBalance.DueYear = MonthAndYear.Year;

                        ProcessTrackingAndFeeBalance.RackFileNo = gstClient.RackFileNo;
                        ProcessTrackingAndFeeBalance.SalesInvoice = null;
                        ProcessTrackingAndFeeBalance.SalesBillsNil = null;
                        ProcessTrackingAndFeeBalance.PurchaseInvoice = null;
                        ProcessTrackingAndFeeBalance.PurchaseNil = null;
                        ProcessTrackingAndFeeBalance.GSTTaxAmount = null;

                        ProcessTrackingAndFeeBalance.FeesAmount = clientFeeMap.DefaultCharge;
                        ProcessTrackingAndFeeBalance.AmountPaid = 0;
                        ProcessTrackingAndFeeBalance.CurrentBalance = clientFeeMap.DefaultCharge;



                        ProcessTrackingAndFeeBalance.ReceivedDate = null;

                        ProcessTrackingAndFeeBalance.SalesFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNotFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNilFiled = null;
                        ProcessTrackingAndFeeBalance.SalesNilNotFiled = null;
                        ProcessTrackingAndFeeBalance.SalesFiledDate = null;

                        ProcessTrackingAndFeeBalance.GSTR3BFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNotFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNILFiled = null;
                        ProcessTrackingAndFeeBalance.GSTR3BNilNotFiled = null;

                        ProcessTrackingAndFeeBalance.GSTR3BFiledDate = null;


                        await dbSet.AddAsync(ProcessTrackingAndFeeBalance);
                        await _context.SaveChangesAsync();

                    }


                }
            }
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
            ProcessTrackingAndFeeBalance ProcessTrackingAndFeeBalance = new();


            foreach (var client in listGSTClients)
            {


                var clientFeeMap = _context.ClientFeeMaps.
                                Where(c => c.GSTClientId == client.Id
                                && c.ReturnFrequencyTypeId == (int)EFrequency.QuaterlyReturn).FirstOrDefault();

                if (clientFeeMap != null)
                {

                    for (int i = 3; i <= 12; i += 3)
                    {
                       // DateTime QuarterMonth = new DateTime(DateTime.Now.Year, i, 1); // i is month in integer


                        var QuarterMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

                        var dueMonth = QuarterMonth.Substring(0, 3) + "-" + DateTime.Now.Year.ToString();
                        var dueYear = DateTime.Now.Year;

                        string monthNameFull = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "-" + todayYear.ToString();
                        //var MonthAndYear = _context.MonthAndYears.Where(m => m.MonthYear == monthNameFull.Substring(0, 3) + "-" + todayYear).FirstOrDefault();
                        var existCollandBal = _context.ProcessTrackingAndFeeBalances.Where(c => c.GSTClientId == client.Id
                                                               && c.ReturnFrequencyTypeId == (int)EFrequency.QuaterlyReturn
                                                               && c.DueMonth == dueMonth
                                                               && c.DueYear == dueYear).Any();

                        if (existCollandBal)
                        {
                            continue;
                        }
                        else
                        {
                            ProcessTrackingAndFeeBalance.GSTClientId = client.Id;
                            ProcessTrackingAndFeeBalance.ReturnFrequencyTypeId = (int)EFrequency.QuaterlyReturn;
                            ProcessTrackingAndFeeBalance.DueMonth = dueMonth;
                            ProcessTrackingAndFeeBalance.DueYear = dueYear;

                            ProcessTrackingAndFeeBalance.RackFileNo = client.RackFileNo;
                            ProcessTrackingAndFeeBalance.SalesInvoice = null;
                            ProcessTrackingAndFeeBalance.SalesBillsNil = null;
                            ProcessTrackingAndFeeBalance.PurchaseInvoice = null;
                            ProcessTrackingAndFeeBalance.PurchaseNil = null;
                            ProcessTrackingAndFeeBalance.GSTTaxAmount = null;

                            ProcessTrackingAndFeeBalance.FeesAmount = clientFeeMap.DefaultCharge;
                            ProcessTrackingAndFeeBalance.AmountPaid = 0;
                            ProcessTrackingAndFeeBalance.CurrentBalance = clientFeeMap.DefaultCharge;



                            ProcessTrackingAndFeeBalance.ReceivedDate = null;

                            ProcessTrackingAndFeeBalance.SalesFiled = null;
                            ProcessTrackingAndFeeBalance.SalesNotFiled = null;
                            ProcessTrackingAndFeeBalance.SalesNilFiled = null;
                            ProcessTrackingAndFeeBalance.SalesNilNotFiled = null;
                            ProcessTrackingAndFeeBalance.SalesFiledDate = null;

                            ProcessTrackingAndFeeBalance.GSTR3BFiled = null;
                            ProcessTrackingAndFeeBalance.GSTR3BNotFiled = null;
                            ProcessTrackingAndFeeBalance.GSTR3BNILFiled = null;
                            ProcessTrackingAndFeeBalance.GSTR3BNilNotFiled = null;

                            ProcessTrackingAndFeeBalance.GSTR3BFiledDate = null;


                            await dbSet.AddAsync(ProcessTrackingAndFeeBalance);
                            await _context.SaveChangesAsync();

                        }
                    }
                    

                    Console.WriteLine("Quaterly Sync CronJob Completed at " + DateTime.Now.ToLocalTime());
                }
            }
        }

        public async Task<ProcessTrackingAndFeeBalance> UpdateAsync(ProcessTrackingAndFeeBalance entity)
        {
            //entity.LastModifiedDate = DateTime.UtcNow;

            _context.Update(entity);
            // await _context.SaveChangesAsync();
            _logger.LogInformation("ProcessTrackingAndFeeBalance Id" + entity.Id.ToString() + " updated");

            return entity;
        }




    }
}
