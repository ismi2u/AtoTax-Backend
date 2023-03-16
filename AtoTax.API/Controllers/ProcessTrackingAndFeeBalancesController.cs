using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using AtoTax.Domain.DTOs;
using AutoMapper;
using System.Net;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Expressions;
using EmailService;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.ComponentModel;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles="User")]
    public class ProcessTrackingAndFeeBalancesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        private readonly ILogger<ProcessTrackingAndFeeBalance> _logger;

        public ProcessTrackingAndFeeBalancesController(IUnitOfWork unitOfWork,
                            IConfiguration config,
                            IMapper mapper,
                            IEmailSender emailSender,
                            ILogger<ProcessTrackingAndFeeBalance> logger,
                            AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _logger = logger;
            _config = config;

        }

        // GET: api/ProcessTrackingAndFeeBalances
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProcessTrackingAndFeeBalances()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ProcessTrackingAndFeeBalanceDTO>>(ProcessTrackingAndFeeBalancesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPendingPaymentList(string month = null, int? year = null)
        {
            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();

            try
            {

                IEnumerable<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalancesList = new List<ProcessTrackingAndFeeBalance>();

                //if (!string.IsNullOrEmpty(month))
                //{
                //    if (year != null || year > 0)
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.CurrentBalance > 0 && c.DueMonth.ToUpper() == month.ToUpper() && c.DueYear == year, 0, 0, arrIncludes);
                //    }
                //    else
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.CurrentBalance > 0 && c.DueMonth.ToUpper() == month.ToUpper(), 0, 0, arrIncludes);
                //    }


                //}
                //else
                //{
                //    if (year != null || year > 0)
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.CurrentBalance > 0 && c.DueYear == year, 0, 0, arrIncludes);
                //    }
                //    else
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.CurrentBalance > 0, 0, 0, arrIncludes);
                //    }

                //}


                _response.Result = _mapper.Map<IEnumerable<ProcessTrackingAndFeeBalanceDTO>>(ProcessTrackingAndFeeBalancesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPendingPaymentListByClient(Guid gstclientid, string month = null, int? year = null)
        {
            List<string> includelist = new List<string>();
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();

            try
            {

                IEnumerable<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalancesList = new List<ProcessTrackingAndFeeBalance>();

                //if (!string.IsNullOrEmpty(month))
                //{
                //    if (year != null || year > 0)
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.GSTClientId == gstclientid && c.CurrentBalance > 0 && c.DueMonth.ToUpper() == month.ToUpper() && c.DueYear == year, 0, 0, arrIncludes);
                //    }
                //    else
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.GSTClientId == gstclientid && c.CurrentBalance > 0 && c.DueMonth.ToUpper() == month.ToUpper(), 0, 0, arrIncludes);
                //    }
                //}
                //else
                //{
                //    if (year != null || year > 0)
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.GSTClientId == gstclientid && c.CurrentBalance > 0 && c.DueYear == year, 0, 0, arrIncludes);
                //    }
                //    else
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.GSTClientId == gstclientid && c.CurrentBalance > 0, 0, 0, arrIncludes);
                //    }
                //}


                _response.Result = _mapper.Map<IEnumerable<ProcessTrackingAndFeeBalanceDTO>>(ProcessTrackingAndFeeBalancesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTFiledStatusList(bool bBillsReceived = false, bool bGSTFiled = false)
        {
            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();

            try
            {

                IEnumerable<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalancesList = new List<ProcessTrackingAndFeeBalance>();

                //if(bBillsReceived)
                //{
                //    if(bGSTFiled)
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.IsGSTBillReceived == true && c.IsGSTFiled == true, 0, 0, arrIncludes);
                //    }
                //    else
                //    {
                //        ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.IsGSTBillReceived == true && c.IsGSTFiled == false, 0, 0, arrIncludes);
                //    }

                //}
                //else
                //{
                //    ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.IsGSTBillReceived == false, 0, 0, arrIncludes);
                //}

                _response.Result = _mapper.Map<IEnumerable<ProcessTrackingAndFeeBalanceDTO>>(ProcessTrackingAndFeeBalancesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillsNotReceivedList(string month = null, int? year = null)
        {
            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();

            try
            {

                IEnumerable<ProcessTrackingAndFeeBalance> ProcessTrackingAndFeeBalancesList = new List<ProcessTrackingAndFeeBalance>();

                ProcessTrackingAndFeeBalancesList = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(c => c.DueMonth.ToUpper() == month.ToUpper() && c.DueYear == year, 0, 0, arrIncludes);


                _response.Result = _mapper.Map<IEnumerable<ProcessTrackingAndFeeBalanceDTO>>(ProcessTrackingAndFeeBalancesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/ProcessTrackingAndFeeBalances/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProcessTrackingAndFeeBalance(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("Frequency");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ProcessTrackingAndFeeBalance ProcessTrackingAndFeeBalance = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ProcessTrackingAndFeeBalanceDTO>(ProcessTrackingAndFeeBalance);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProcessPopupDataForGSTClient(Guid id)
        {

            if (id == Guid.Empty)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient Id" };
                return Ok(_response);
            }

            GSTClient gstClient = await _unitOfWork.GSTClients.GetAsync(g => g.Id == id);

            if (gstClient == null)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient" };
                return Ok(_response);
            }

            try
            {
                var ProcessTrackingAndFeeBalances = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(u => u.GSTClientId == id);

                GSTClientPopupDataDTO gstClientPopupDataDTO = new();
                gstClientPopupDataDTO.TotalPendingBalance = _unitOfWork.ProcessTrackingAndFeeBalances
                                                                    .GetAllAsync(p => p.GSTClientId == id && p.ReturnFrequencyTypeId != (int)EFrequency.AnnualReturn).Result
                                                                    .Select(s => s.CurrentBalance).Sum() ?? 0;


                gstClientPopupDataDTO.GSTClientId = gstClient.Id;
                gstClientPopupDataDTO.PropreitorName = gstClient.ProprietorName;
                gstClientPopupDataDTO.RackFileNo = gstClient.RackFileNo;
                gstClientPopupDataDTO.TallyDataFilePath = gstClient.TallyDataFilePath;
                gstClientPopupDataDTO.ClientRelationMgr = _context.ApplicationUsers.FirstOrDefault(u => u.Id == gstClient.ClientRelationMgrId.ToString()).Name;
                gstClientPopupDataDTO.ReturnFrequency = gstClient.isRegular ? "Monthly-Return" : "Quaterly-Return";
                gstClientPopupDataDTO.CurrentFees = 0;// change this later


                _response.Result = gstClientPopupDataDTO;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.SuccessMessage = "GST Client Data";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetReturnFrequenciesforGSTClient(Guid id)
        {

            if (id == Guid.Empty)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient Id" };
                return Ok(_response);
            }

            GSTClient gstClient = await _unitOfWork.GSTClients.GetAsync(g => g.Id == id);

            if (gstClient == null)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient" };
                return Ok(_response);
            }

            IEnumerable<ProcessTrackingAndFeeBalance> listTrackingAndFeeBalances = await _unitOfWork.ProcessTrackingAndFeeBalances
                                                                        .GetAllAsync(c => c.GSTClientId == id);


            try
            {
                GetFrequencyInputDTO getFrequencyInputDTO = new GetFrequencyInputDTO();

                //List<string> listMonths = new List<string>();
                //foreach (var item in listTrackingAndFeeBalances)
                //{
                //    if(item.DueMonth != null)
                //    {
                //        listMonths.Add(item.DueMonth);
                //    }
                    
                //}
                //getS1ProcessInputDTO.DueMonths = listMonths;


                List<ClientReturnFrequencyForDD> listReturnFreq = new List<ClientReturnFrequencyForDD>();
                foreach (var item in listTrackingAndFeeBalances)
                {
                    ClientReturnFrequencyForDD returnFrequency = new ClientReturnFrequencyForDD();
                    returnFrequency.Id = item.ReturnFrequencyTypeId;
                    returnFrequency.ReturnFreqType = _unitOfWork.ReturnFrequencyTypes.GetAsync(m => m.Id == item.ReturnFrequencyTypeId).Result.ReturnFreqType;
                    if(!listReturnFreq.Any(f=> f.ReturnFreqType == returnFrequency.ReturnFreqType))
                    {
                        listReturnFreq.Add(returnFrequency);
                    }


                }
                getFrequencyInputDTO.GSTClientId = gstClient.Id;
                //getS1ProcessInputDTO.DueMonths = listMonths;
                getFrequencyInputDTO.listReturnFreqTypes = listReturnFreq;

                _response.Result = getFrequencyInputDTO;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.SuccessMessage = "";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Result = "";
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetYearsInputforGSTClient([FromQuery]GSTClientIdAndFreqIdTO gstClientIdFreq)
        {

            GetYearsInputDTO getYearsInputDTO = new GetYearsInputDTO();

            Dictionary<int, double> listYears = new Dictionary<int, double>();

            var listProcessAndFeeBals = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(p => p.GSTClientId == gstClientIdFreq.GSTClientId && p.ReturnFrequencyTypeId == gstClientIdFreq.FrequencyId);

            getYearsInputDTO.GSTClientId = gstClientIdFreq.GSTClientId;


            foreach (var item in listProcessAndFeeBals)
            {
                if (item.ReceivedDate == null && string.IsNullOrEmpty(item.ReceivedByUser))
                {

                    listYears.Add(item.DueYear ?? 0, item.FeesAmount?? 0);

                    //if (!listYears.Contains(item.DueYear ?? 0))
                    //{
                    //    listYears.Add(item.DueYear ?? 0);
                    //}
                }
            }
            getYearsInputDTO.ReturnFrequencyTypeId = gstClientIdFreq.FrequencyId;
            getYearsInputDTO.YearsAndAmount = listYears;

            _response.Result = getYearsInputDTO;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.SuccessMessage = "";
            return Ok(_response);


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMonthsInputforGSTClient([FromQuery] GSTClientFreqYearDTO gstClientFreqYearDTO)
        {

            GetMonthsInputDTO getMonthsInputDTO = new GetMonthsInputDTO();

            List<string> listMonths = new List<string>();

            var listProcessAndFeeBals = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAllAsync(p => p.GSTClientId == gstClientFreqYearDTO.GSTClientId 
            && p.ReturnFrequencyTypeId == gstClientFreqYearDTO.FrequencyId
            && p.DueYear == gstClientFreqYearDTO.Year);

            getMonthsInputDTO.GSTClientId = gstClientFreqYearDTO.GSTClientId;
            getMonthsInputDTO.ReturnFrequencyTypeId = gstClientFreqYearDTO.FrequencyId;
            getMonthsInputDTO.Year = gstClientFreqYearDTO.Year;

         

            foreach (var item in listProcessAndFeeBals)
            {

                if(item.ReceivedDate == null && string.IsNullOrEmpty( item.ReceivedByUser))
                {
                    if (!listMonths.Contains(item.DueMonth))
                    {
                        listMonths.Add(item.DueMonth);
                    }
                }

            }
            getMonthsInputDTO.dueMonths = listMonths;

            _response.Result = getMonthsInputDTO;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.SuccessMessage = "";
            return Ok(_response);


        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetInputForGSTR1ForGSTClient(Guid id)
        {

            if (id == Guid.Empty)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient Id" };
                return Ok(_response);
            }

            GSTClient gstClient = await _unitOfWork.GSTClients.GetAsync(g => g.Id == id);

            if (gstClient == null)
            {
                _response.Result = null;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "Invalid GSTClient" };
                return Ok(_response);
            }

            IEnumerable<ProcessTrackingAndFeeBalance> listTrackingAndFeeBalances = await _unitOfWork.ProcessTrackingAndFeeBalances
                                                                        .GetAllAsync(c => c.GSTClientId == id && c.ReceivedByUser != null);


            //try
            //{
            //    GetS1ProcessInputDTO getS1ProcessInputDTO = new GetS1ProcessInputDTO();

            //    List<string> listMonths = new List<string>();
            //    foreach (var item in listTrackingAndFeeBalances)
            //    {
            //        if (item.DueMonth != null)
            //        {
            //            listMonths.Add(item.DueMonth);
            //        }

            //    }
            //    getS1ProcessInputDTO.DueMonths = listMonths;


            //    List<ClientReturnFrequencyForDD> listReturnFreq = new List<ClientReturnFrequencyForDD>();
            //    foreach (var item in listTrackingAndFeeBalances)
            //    {
            //        ClientReturnFrequencyForDD returnFrequency = new ClientReturnFrequencyForDD();
            //        returnFrequency.Id = item.ReturnFrequencyTypeId;
            //        returnFrequency.ReturnFreqType = _unitOfWork.ReturnFrequencyTypes.GetAsync(m => m.Id == item.ReturnFrequencyTypeId).Result.ReturnFreqType;
            //        if (!listReturnFreq.Contains(returnFrequency))
            //        {
            //            listReturnFreq.Add(returnFrequency);
            //        }


            //    }
            //    getS1ProcessInputDTO.GSTClientId = gstClient.Id;
            //    getS1ProcessInputDTO.DueMonths = listMonths;
            //    getS1ProcessInputDTO.listReturnFreqTypes = listReturnFreq;

            ////    _response.Result = getS1ProcessInputDTO;
            //    _response.IsSuccess = true;
            //    _response.StatusCode = HttpStatusCode.OK;
            //    _response.SuccessMessage = "Retrieved the requested data";
            //    return Ok(_response);
            //}
            //catch (Exception ex)
            //{
            //    _response.Result = "";
            //    _response.IsSuccess = false;
            //    _response.StatusCode = HttpStatusCode.BadRequest;
            //    _response.ErrorMessages = new List<string>() { ex.ToString() };
            //}
            return Ok(_response);


        }



        [HttpPut]
        // PUT: api/ProcessTrackingAndFeeBalances/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateProcessInvoicesReceived(UpdateS1ProcessDataDTO updateS1ProcessDataDTO)
        {

            if ( updateS1ProcessDataDTO.GSTClientId == Guid.Empty)
            {
                _response.Result = updateS1ProcessDataDTO.GSTClientId;
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { "GSTClientId is not valid" };

                return Ok(_response);
            }

            try
            {
                var processTrackingAndFeeBalance = await _unitOfWork.ProcessTrackingAndFeeBalances
                                                    .GetAsync(u => u.GSTClientId == updateS1ProcessDataDTO.GSTClientId
                                                    && u.DueMonth == updateS1ProcessDataDTO.DueMonth
                                                    && u.DueYear == updateS1ProcessDataDTO.DueYear
                                                    && u.ReturnFrequencyTypeId == updateS1ProcessDataDTO.ReturnFrequencyTypeId, tracked: true);

                if (processTrackingAndFeeBalance == null)
                {
                    _response.Result = updateS1ProcessDataDTO;
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Process Tracking record is null" };
                    return Ok(_response);
                }

                processTrackingAndFeeBalance.SalesInvoice = updateS1ProcessDataDTO.SalesInvoice;
                processTrackingAndFeeBalance.SalesBillsNil = updateS1ProcessDataDTO.SalesBillsNil;
                processTrackingAndFeeBalance.PurchaseInvoice = updateS1ProcessDataDTO.PurchaseInvoice;
                processTrackingAndFeeBalance.PurchaseNil = updateS1ProcessDataDTO.PurchaseNil;
                processTrackingAndFeeBalance.GSTTaxAmount = updateS1ProcessDataDTO.GSTTaxAmount;
                processTrackingAndFeeBalance.AmountPaid = updateS1ProcessDataDTO.AmountPaid;
                processTrackingAndFeeBalance.CurrentBalance = processTrackingAndFeeBalance.CurrentBalance - processTrackingAndFeeBalance.AmountPaid;
                processTrackingAndFeeBalance.PurchaseNil = updateS1ProcessDataDTO.PurchaseNil;
                processTrackingAndFeeBalance.ReceivedDate = DateTime.UtcNow;
                processTrackingAndFeeBalance.ReceivedByUser = User.Identity.Name;


                await _unitOfWork.ProcessTrackingAndFeeBalances.UpdateAsync(processTrackingAndFeeBalance);

                await _unitOfWork.CompleteAsync();


                var gstClient = await _unitOfWork.GSTClients.GetAsync(u => u.Id == updateS1ProcessDataDTO.GSTClientId);
                // Send Mail ID confirmation email

                string[] paths = { Directory.GetCurrentDirectory(), "GSTBillsReceived.html" };
                string FilePath = Path.Combine(paths);
                // _logger.LogInformation("Email template path " + FilePath);
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();

                var domain = _config.GetSection("Domain").Value;
                var duemonth = processTrackingAndFeeBalance.DueMonth;
                var dueyear = processTrackingAndFeeBalance.DueYear;
                var builder = new MimeKit.BodyBuilder();
                var receiverEmail = gstClient.GSTEmailId;
                string subject = "AtoTax: GST Bills Received for the month of " + duemonth + "-" + dueyear;

                MailText = MailText.Replace("{Domain}", domain);
                MailText = MailText.Replace("{employee}", User.Identity.Name);
                MailText = MailText.Replace("{month}", duemonth);
                MailText = MailText.Replace("{year}", dueyear.ToString());
                MailText = MailText.Replace("{gstclient}", gstClient.ProprietorName);


                builder.HtmlBody = MailText;

                EmailDto emailDto = new EmailDto();
                emailDto.To = receiverEmail;
                emailDto.Subject = subject;
                emailDto.Body = builder.HtmlBody;

                await _emailSender.SendEmailAsync(emailDto);
                _logger.LogInformation("Email Acknowledgement: Acknowledgement sent to " + gstClient.ProprietorName + " for the month of " + duemonth + "-" + dueyear);
                ///

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Received the Invoices";
                _response.Result = processTrackingAndFeeBalance;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        //// POST: api/ProcessTrackingAndFeeBalances
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> CreateProcessTrackingAndFeeBalance(ProcessTrackingAndFeeBalanceCreateDTO ProcessTrackingAndFeeBalanceCreateDTO)
        //{
        //    try
        //    {

        //        //if (await _dbProcessTrackingAndFeeBalance.GetAsync(u => u.FilingType == ProcessTrackingAndFeeBalanceCreateDTO.FilingType) != null)
        //        //{
        //        //    _response.StatusCode = HttpStatusCode.BadRequest;
        //        //    return Ok(_response);
        //        //}

        //        var ProcessTrackingAndFeeBalance = _mapper.Map<ProcessTrackingAndFeeBalance>(ProcessTrackingAndFeeBalanceCreateDTO);
        //        //ProcessTrackingAndFeeBalance.CreatedDate= DateTime.UtcNow;
        //        await _unitOfWork.ProcessTrackingAndFeeBalances.CreateAsync(ProcessTrackingAndFeeBalance);

        //        await _unitOfWork.CompleteAsync();
        //        _response.Result = _mapper.Map<ProcessTrackingAndFeeBalanceDTO>(ProcessTrackingAndFeeBalance);
        //        _response.StatusCode = HttpStatusCode.Created;
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "ProcessTrackingAndFeeBalance created successfully";


        //        return CreatedAtAction("GetProcessTrackingAndFeeBalance", new { id = ProcessTrackingAndFeeBalance.Id }, _response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}

        //// DELETE: api/ProcessTrackingAndFeeBalances/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<APIResponse>> DeleteProcessTrackingAndFeeBalance(Guid id)
        //{
        //    try
        //    {
        //        if (id == Guid.Empty)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var ProcessTrackingAndFeeBalance = await _unitOfWork.ProcessTrackingAndFeeBalances.GetAsync(u => u.Id == id);
        //        if (ProcessTrackingAndFeeBalance == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            return NotFound(_response);
        //        }

        //        await _unitOfWork.ProcessTrackingAndFeeBalances.RemoveAsync(ProcessTrackingAndFeeBalance);

        //        await _unitOfWork.CompleteAsync();
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}

    }
}
