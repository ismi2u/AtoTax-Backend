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
    //[Authorize(Roles="User")]
    public class GSTBillAndFeeCollectionController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<GSTBillAndFeeCollection> _logger;

        public GSTBillAndFeeCollectionController(IUnitOfWork unitOfWork, IMapper mapper,
            IConfiguration config, 
            AtoTaxDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, ILogger<GSTBillAndFeeCollection> logger)
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

        // GET: api/GSTBillAndFeeCollection
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("GSTFilingType");
            includelist.Add("ServiceCategory");
            includelist.Add("MultimediaType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTBillAndFeeCollection> GSTBillAndFeeCollectionList = await _unitOfWork.GSTBillAndFeeCollections.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTBillAndFeeCollectionDTO>>(GSTBillAndFeeCollectionList);
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

        // GET: api/GSTBillAndFeeCollection/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("GSTFilingType");
            includelist.Add("ServiceCategory");
            includelist.Add("MultimediaType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTBillAndFeeCollection GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
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

        // PUT: api/GSTBillAndFeeCollection/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTBillAndFeeCollection(Guid id, 
            GSTBillAndFeeCollectionUpdateDTO GSTBillAndFeeCollectionUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection modelstate invalid" };
                return Ok(_response);
            }


            try
            {
                if (id == Guid.Empty || !(id == GSTBillAndFeeCollectionUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update GSTBillAndFeeCollection failed" };
                    return Ok(_response);
                }

               

                var oldGSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection data is Null" };
                    return Ok(_response);
                }

                GSTClient gstclient = await _unitOfWork.GSTClients.GetAsync(c => c.Id == oldGSTBillAndFeeCollection.GSTClientId);



                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionUpdateDTO);

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
                    var duemonth = GSTBillAndFeeCollection.DueMonth;
                    var dueyear = GSTBillAndFeeCollection.DueYear;
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
                    GSTBillAndFeeCollection.FiledBy = loggedUserName;
                    GSTBillAndFeeCollection.IsFiled = true;
                    GSTBillAndFeeCollection.GSTFiledAckEmailSent = true;
                    GSTBillAndFeeCollection.GSTFiledAckSMSSent = false;
                }
                catch (Exception)
                {
                    strEmailNotSentError = "GST Filed Acknowledgement could not be sent to GST Client";
                }


                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //GSTBillAndFeeCollection.CreatedDate = oldGSTBillAndFeeCollection.CreatedDate;

                await _unitOfWork.GSTBillAndFeeCollections.UpdateAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTBillAndFeeCollection;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTBillAndFeeCollection updated " + strEmailNotSentError;
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

        // POST: api/GSTBillAndFeeCollection
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTBillAndFeeCollection(GSTBillAndFeeCollectionCreateDTO GSTBillAndFeeCollectionCreateDTO)
        {
            string loggedUserName = User.Identity.Name;

            bool recordAlreadyExists =   _unitOfWork.GSTBillAndFeeCollections.GetAllAsync(g=> g.GSTClientId == GSTBillAndFeeCollectionCreateDTO.GSTClientID && g.DueMonth == GSTBillAndFeeCollectionCreateDTO.DueMonth  && g.DueYear == GSTBillAndFeeCollectionCreateDTO.DueYear && g.ServiceCategoryId == GSTBillAndFeeCollectionCreateDTO.ServiceCategoryId).Result.Any();

            if(recordAlreadyExists)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "Duplicate record not allowed" };
            }

            try
            {
                var clientFeeMap = _unitOfWork.ClientFeeMaps.GetAllAsync(c => c.GSTClientId == GSTBillAndFeeCollectionCreateDTO.GSTClientID 
                                        && c.ServiceCategoryId == GSTBillAndFeeCollectionCreateDTO.ServiceCategoryId).Result.FirstOrDefault();

                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionCreateDTO);
                GSTBillAndFeeCollection.ReceivedBy = loggedUserName;
                GSTBillAndFeeCollection.IsBillsReceived = true;
                GSTBillAndFeeCollection.IsFiled = false;
                GSTBillAndFeeCollection.FeesAmount = clientFeeMap.DefaultCharge;
                GSTBillAndFeeCollection.Balance = clientFeeMap.DefaultCharge;

                GSTClient gstclient = new();
                if (GSTBillAndFeeCollectionCreateDTO.GSTClientID != null)
                {
                   gstclient = await _unitOfWork.GSTClients.GetAsync(c => c.Id == GSTBillAndFeeCollectionCreateDTO.GSTClientID);
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
                    var duemonth = GSTBillAndFeeCollectionCreateDTO.DueMonth;
                    var dueyear = GSTBillAndFeeCollectionCreateDTO.DueYear;
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

                    GSTBillAndFeeCollection.ReceivedAckEmailSent = true;
                    GSTBillAndFeeCollection.ReceivedAckSMSSent = false;
                }
                catch (Exception)
                {
                    strEmailNotSentError = "Email Acknowledge could not be sent to GST Client";
                }
                

                await _unitOfWork.GSTBillAndFeeCollections.CreateAsync(GSTBillAndFeeCollection);

                /// Create entry in Collection in Balance for IsBillsreceived and IsGSTFiled

               CollectionAndBalance updCollectionAndBalance =  _unitOfWork.CollectionAndBalances.GetAllAsync(c=> c.GSTClientId == GSTBillAndFeeCollectionCreateDTO.GSTClientID 
               && c.DueMonth == GSTBillAndFeeCollectionCreateDTO.DueMonth 
               && c.DueYear == GSTBillAndFeeCollectionCreateDTO.DueYear
               && c.ServiceCategoryId == GSTBillAndFeeCollectionCreateDTO.ServiceCategoryId).Result.FirstOrDefault();
                if(updCollectionAndBalance != null)
                {
                    updCollectionAndBalance.IsGSTBillReceived = true;
                    updCollectionAndBalance.IsGSTFiled = false;
                    updCollectionAndBalance.CurrentBalance = GSTBillAndFeeCollection.FeesAmount ?? 0;
                    updCollectionAndBalance.FeesAmount = GSTBillAndFeeCollection.FeesAmount ?? 0;
                    updCollectionAndBalance.AmountPaid = 0;

                    await _unitOfWork.CollectionAndBalances.UpdateAsync(updCollectionAndBalance);
                }
                else
                {// this record already created by Hangfire CRON job, but in case if it missed due 
                 // to trigger time, create a record
                    CollectionAndBalance NewCollectionAndBalance = new();
                    NewCollectionAndBalance.GSTClientId = GSTBillAndFeeCollection.GSTClientId;
                    NewCollectionAndBalance.DueMonth = GSTBillAndFeeCollection.DueMonth;
                    NewCollectionAndBalance.DueYear = GSTBillAndFeeCollection.DueYear;
                    NewCollectionAndBalance.FeesAmount = GSTBillAndFeeCollection.FeesAmount;
                    NewCollectionAndBalance.CurrentBalance = GSTBillAndFeeCollection.FeesAmount ?? 0;
                    NewCollectionAndBalance.ServiceCategoryId = GSTBillAndFeeCollectionCreateDTO.ServiceCategoryId;//GSTMonthlySubmission
                    NewCollectionAndBalance.AmountPaid = 0;

                    await _unitOfWork.CollectionAndBalances.CreateAsync(NewCollectionAndBalance);
                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New GSTBillAndFeeCollection created " + strEmailNotSentError;
                _response.ErrorMessages = null;

                return CreatedAtAction("GetGSTBillAndFeeCollection", new { id = GSTBillAndFeeCollection.Id }, _response);
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



        // DELETE: api/GSTBillAndFeeCollection/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTBillAndFeeCollection(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection Id not found" };
                    return Ok(_response);
                }
                var GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id);
                if (GSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection not found" };
                    return Ok(_response);
                }

                await _unitOfWork.GSTBillAndFeeCollections.RemoveAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTBillAndFeeCollection;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTBillAndFeeCollection deleted";
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

    }
}
