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
using AtoTax.API.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AtoTax.Domain.DTOs.AuthDTOs;
using EmailService;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="User")]
    public class GSTBillsProcessingController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<GSTBillsProcessing> _logger;

        public GSTBillsProcessingController(IUnitOfWork unitOfWork, IMapper mapper,
            IConfiguration config, 
            AtoTaxDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, ILogger<GSTBillsProcessing> logger)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _config = config;
            _emailSender = emailSender;
            _logger = logger;
        }

        // GET: api/GSTBillsProcessing
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillsProcessing()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("GSTFilingType");
            includelist.Add("ServiceCategory");
            includelist.Add("MultimediaType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTBillsProcessing> GSTBillsProcessingList = await _unitOfWork.GSTBillsProcessings.GetAllAsync(null, 0, 0, arrIncludes);
                _response.Result = _mapper.Map<IEnumerable<GSTBillsProcessingDTO>>(GSTBillsProcessingList);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/GSTBillsProcessing/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillsProcessing(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("GSTFilingType");
            includelist.Add("ServiceCategory");
            includelist.Add("MultimediaType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTBillsProcessing GSTBillsProcessing = await _unitOfWork.GSTBillsProcessings.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTBillsProcessingDTO>(GSTBillsProcessing);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
           
        }

        // PUT: api/GSTBillsProcessing/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTBillsProcessing(Guid id, 
            GSTBillsProcessingUpdateDTO GSTBillsProcessingUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = GSTBillsProcessingUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "GSTBillsProcessing modelstate invalid" };
                return Ok(_response);
            }


            try
            {
                if (id == Guid.Empty || !(id == GSTBillsProcessingUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = GSTBillsProcessingUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update GSTBillsProcessing failed" };
                    return Ok(_response);
                }

               

                var oldGSTBillsProcessing = await _unitOfWork.GSTBillsProcessings.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTBillsProcessing == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = GSTBillsProcessingUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillsProcessing data is Null" };
                    return Ok(_response);
                }

                GSTClient gstclient = await _unitOfWork.GSTClients.GetAsync(c => c.Id == oldGSTBillsProcessing.GSTClientId);



                //var GSTBillsProcessing = _mapper.Map<GSTBillsProcessing>(GSTBillsProcessingUpdateDTO);

                //// dont update the FilingType number which is the Identity of the FilingType
                string loggedUserName = User.Identity.Name;


               
                string strEmailNotSentError = string.Empty;
                try
                {
                    // Send Mail ID confirmation email

                    string[] paths = { Directory.GetCurrentDirectory(), "GSTBillsReceived.html" };
                    string FilePath = Path.Combine(paths);
                    // _logger.LogInformation("Email template path " + FilePath);
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();

                    var domain = _config.GetSection("Domain").Value;
                    var duemonth = oldGSTBillsProcessing.DueMonth;
                    var dueyear = oldGSTBillsProcessing.DueYear;
                    var builder = new MimeKit.BodyBuilder();
                    var receiverEmail = gstclient.GSTEmailId;
                    string subject = "AtoTax: GST Filed for the month of " + duemonth + "-" + dueyear;

                    MailText = MailText.Replace("{Domain}", domain);
                    MailText = MailText.Replace("{employee}", loggedUserName);
                    MailText = MailText.Replace("{month}", duemonth);
                    MailText = MailText.Replace("{year}", dueyear.ToString());
                    MailText = MailText.Replace("{gstclient}", gstclient.ProprietorName);


                    builder.HtmlBody = MailText;

                    EmailDto emailDto = new EmailDto();
                    emailDto.To = receiverEmail;
                    emailDto.Subject = subject;
                    emailDto.Body = builder.HtmlBody;

                    await _emailSender.SendEmailAsync(emailDto);
                    _logger.LogInformation("GST Filed Acknowledgement for " + gstclient.ProprietorName + " for the month of " + " for the month of " + duemonth + "-" + dueyear);
                    ///
                    oldGSTBillsProcessing.FiledBy = loggedUserName;
                    oldGSTBillsProcessing.IsFiled = true;
                    oldGSTBillsProcessing.GSTFiledAckEmailSent = true;
                    oldGSTBillsProcessing.GSTFiledAckSMSSent = false;
                }
                catch (Exception)
                {
                    strEmailNotSentError = "GST Filed Acknowledgement could not be sent to GST Client";
                }


                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //GSTBillsProcessing.CreatedDate = oldGSTBillsProcessing.CreatedDate;

                await _unitOfWork.GSTBillsProcessings.UpdateAsync(oldGSTBillsProcessing);



                //GST Filed should be set to true
                CollectionAndBalance updCollectionAndBalance = _unitOfWork.CollectionAndBalances.GetAllAsync(c => c.GSTClientId == oldGSTBillsProcessing.GSTClientId
              && c.DueMonth == oldGSTBillsProcessing.DueMonth
              && c.DueYear == oldGSTBillsProcessing.DueYear
              && c.ServiceCategoryId == oldGSTBillsProcessing.ServiceCategoryId).Result.FirstOrDefault();
                if (updCollectionAndBalance != null)
                {

                    updCollectionAndBalance.IsGSTFiled = true;

                    await _unitOfWork.CollectionAndBalances.UpdateAsync(updCollectionAndBalance);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Warning: Collection and Balance Table record missing" };
                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = oldGSTBillsProcessing;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTBillsProcessing updated " + strEmailNotSentError;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }

        // POST: api/GSTBillsProcessing
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTBillsProcessing(GSTBillsProcessingCreateDTO GSTBillsProcessingCreateDTO)
        {
            string loggedUserName = User.Identity.Name;

            bool recordAlreadyExists =   _unitOfWork.GSTBillsProcessings.GetAllAsync(g=> g.GSTClientId == GSTBillsProcessingCreateDTO.GSTClientID && g.DueMonth == GSTBillsProcessingCreateDTO.DueMonth  && g.DueYear == GSTBillsProcessingCreateDTO.DueYear).Result.Any();

            // && g.ServiceCategoryId == GSTBillsProcessingCreateDTO.ServiceCategoryId

            if (recordAlreadyExists)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "Duplicate record not allowed" };
            }

            try
            {
                var clientFeeMap = _unitOfWork.ClientFeeMaps.GetAllAsync(c => c.GSTClientId == GSTBillsProcessingCreateDTO.GSTClientID 
                                        && c.ServiceCategoryId == GSTBillsProcessingCreateDTO.ServiceCategoryId).Result.FirstOrDefault();

                var GSTBillsProcessing = _mapper.Map<GSTBillsProcessing>(GSTBillsProcessingCreateDTO);
                GSTBillsProcessing.ReceivedBy = loggedUserName;
                GSTBillsProcessing.IsBillsReceived = true;
                GSTBillsProcessing.IsFiled = false;

                GSTClient gstclient = new();
                if (GSTBillsProcessingCreateDTO.GSTClientID != null)
                {
                   gstclient = await _unitOfWork.GSTClients.GetAsync(c => c.Id == GSTBillsProcessingCreateDTO.GSTClientID);
                }

                string strEmailNotSentError = string.Empty;
                try
                {
                    // Send Mail ID confirmation email

                    string[] paths = { Directory.GetCurrentDirectory(), "GSTBillsReceived.html" };
                    string FilePath = Path.Combine(paths);
                    // _logger.LogInformation("Email template path " + FilePath);
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();

                    var domain = _config.GetSection("Domain").Value;
                    var duemonth = GSTBillsProcessingCreateDTO.DueMonth;
                    var dueyear = GSTBillsProcessingCreateDTO.DueYear;
                    var builder = new MimeKit.BodyBuilder();
                    var receiverEmail = gstclient.GSTEmailId;
                    string subject = "AtoTax: GST Bills Received for the month of " + duemonth + "-" + dueyear;

                    MailText = MailText.Replace("{Domain}", domain);
                    MailText = MailText.Replace("{employee}", loggedUserName);
                    MailText = MailText.Replace("{month}", duemonth);
                    MailText = MailText.Replace("{year}", dueyear.ToString());
                    MailText = MailText.Replace("{gstclient}", gstclient.ProprietorName);


                    builder.HtmlBody = MailText;

                    EmailDto emailDto = new EmailDto();
                    emailDto.To = receiverEmail;
                    emailDto.Subject = subject;
                    emailDto.Body = builder.HtmlBody;

                    await _emailSender.SendEmailAsync(emailDto);
                    _logger.LogInformation("Email Acknowledgement: Acknowledgement sent to " + gstclient.ProprietorName + " for the month of " + duemonth + "-" + dueyear);
                    ///

                    GSTBillsProcessing.ReceivedAckEmailSent = true;
                    GSTBillsProcessing.ReceivedAckSMSSent = false;
                }
                catch (Exception)
                {
                    strEmailNotSentError = "Email Acknowledge could not be sent to GST Client";
                }
                

                await _unitOfWork.GSTBillsProcessings.CreateAsync(GSTBillsProcessing);

                /// Create entry in Collection in Balance for IsBillsreceived and IsGSTFiled

               CollectionAndBalance updCollectionAndBalance =  _unitOfWork.CollectionAndBalances.GetAllAsync(c=> c.GSTClientId == GSTBillsProcessingCreateDTO.GSTClientID 
               && c.DueMonth == GSTBillsProcessingCreateDTO.DueMonth 
               && c.DueYear == GSTBillsProcessingCreateDTO.DueYear
               && c.ServiceCategoryId == GSTBillsProcessingCreateDTO.ServiceCategoryId).Result.FirstOrDefault();
                if(updCollectionAndBalance != null)
                {
                    updCollectionAndBalance.IsGSTBillReceived = true;
                    updCollectionAndBalance.IsGSTFiled = false;
                    updCollectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;
                    updCollectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                    updCollectionAndBalance.AmountPaid = 0;

                    await _unitOfWork.CollectionAndBalances.UpdateAsync(updCollectionAndBalance);
                }
                else
                {// this record already created by Hangfire CRON job, but in case if it missed due 
                 // to trigger time, create a record
                    CollectionAndBalance NewCollectionAndBalance = new();
                    NewCollectionAndBalance.GSTClientId = GSTBillsProcessing.GSTClientId;
                    NewCollectionAndBalance.DueMonth = GSTBillsProcessing.DueMonth;
                    NewCollectionAndBalance.DueYear = GSTBillsProcessing.DueYear;
                    NewCollectionAndBalance.FeesAmount = clientFeeMap.DefaultCharge;
                    NewCollectionAndBalance.CurrentBalance = clientFeeMap.DefaultCharge;
                    NewCollectionAndBalance.AmountPaid = 0;
                    NewCollectionAndBalance.ServiceCategoryId = GSTBillsProcessingCreateDTO.ServiceCategoryId;//GSTMonthlySubmission
                    NewCollectionAndBalance.IsGSTBillReceived = true;
                    NewCollectionAndBalance.IsGSTFiled = false;

                    await _unitOfWork.CollectionAndBalances.CreateAsync(NewCollectionAndBalance);
                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<GSTBillsProcessingDTO>(GSTBillsProcessing);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New GSTBillsProcessing created " + strEmailNotSentError;
                _response.ErrorMessages = null;

                return CreatedAtAction("GetGSTBillsProcessing", new { id = GSTBillsProcessing.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }



        //// DELETE: api/GSTBillsProcessing/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<APIResponse>> DeleteGSTBillsProcessing(Guid id)
        //{
        //    try
        //    {
        //        if (id == Guid.Empty)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.Result = null;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "GSTBillsProcessing Id not found" };
        //            return Ok(_response);
        //        }
        //        var GSTBillsProcessing = await _unitOfWork.GSTBillsProcessings.GetAsync(u => u.Id == id);
        //        if (GSTBillsProcessing == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            _response.Result = null;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "GSTBillsProcessing not found" };
        //            return Ok(_response);
        //        }

        //        await _unitOfWork.GSTBillsProcessings.RemoveAsync(GSTBillsProcessing);

        //        await _unitOfWork.CompleteAsync();

        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = GSTBillsProcessing;
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "GSTBillsProcessing deleted";
        //        _response.ErrorMessages = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = null;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string> { ex.Message.ToString() };
        //    }
        //    return Ok(_response);
        //}

    }
}
