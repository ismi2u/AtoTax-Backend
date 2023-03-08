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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles="User")]
    public class ClientMonthlyPaymentsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AtoTaxDbContext _context;

        public ClientMonthlyPaymentsController(IUnitOfWork unitOfWork, IMapper mapper,
            UserManager<ApplicationUser> userManager, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork= unitOfWork;
            _userManager = userManager;
        }

        // GET: api/ClientMonthlyPayments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientMonthlyPayments()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");

            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ClientMonthlyPayment> ClientMonthlyPaymentsList = await _unitOfWork.ClientMonthlyPayments.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ClientMonthlyPaymentDTO>>(ClientMonthlyPaymentsList);
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

        // GET: api/ClientMonthlyPayments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientMonthlyPayment(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ClientMonthlyPayment ClientMonthlyPayment = await _unitOfWork.ClientMonthlyPayments.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ClientMonthlyPaymentDTO>(ClientMonthlyPayment);
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

        // POST: api/ClientMonthlyPayments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateClientMonthlyPayment(ClientMonthlyPaymentCreateDTO ClientMonthlyPaymentCreateDTO)
        {
            if(ClientMonthlyPaymentCreateDTO.ReceivedAmount <= 0 || ClientMonthlyPaymentCreateDTO.ReceivedAmount == null)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "Payment amount should be greater than Zero" };
                return Ok(_response);
            }

            try
            {
                string loggedUserName = User.Identity.Name;

                var ClientMonthlyPayment = _mapper.Map<ClientMonthlyPayment>(ClientMonthlyPaymentCreateDTO);
                ClientMonthlyPayment.TransactionRecordedBy = loggedUserName;

                await _unitOfWork.ClientMonthlyPayments.CreateAsync(ClientMonthlyPayment);
                
                
                // Now Add a record in Account Ledger for accounts keeping
                    AccountLedger NewAccountLedgerEntry = new();
                    NewAccountLedgerEntry.IncomeAmount = ClientMonthlyPaymentCreateDTO.ReceivedAmount;
                    NewAccountLedgerEntry.PaymentTypeId = ClientMonthlyPaymentCreateDTO.PaymentTypeId;
                    NewAccountLedgerEntry.TransactionReferenceNo = ClientMonthlyPaymentCreateDTO.PaymentReferenceNumber;
                    NewAccountLedgerEntry.TransactionRecordedBy = loggedUserName;
                    NewAccountLedgerEntry.IsGSTClientPaid = true;
                    NewAccountLedgerEntry.Comments = "Refer: GST Client Payment amount";

                await _unitOfWork.AccountLedgers.CreateAsync(NewAccountLedgerEntry);
                ////


                //Now tally the Collection and balance for the respective period (March 2023) 
                var updCollectionAndBalance = _unitOfWork.CollectionAndBalances.GetAllAsync(
                                                        c => c.GSTClientId == ClientMonthlyPaymentCreateDTO.GSTClientId
                                                        && c.DueMonth == ClientMonthlyPaymentCreateDTO.DueMonth
                                                        && c.DueYear == ClientMonthlyPaymentCreateDTO.DueYear
                                                        && c.ServiceCategoryId == ClientMonthlyPaymentCreateDTO.ServiceCategoryId)
                                                    .Result.FirstOrDefault();

                if (updCollectionAndBalance != null)
                {
                    updCollectionAndBalance.AmountPaid = ClientMonthlyPaymentCreateDTO.ReceivedAmount ?? 0;
                    updCollectionAndBalance.CurrentBalance = updCollectionAndBalance.CurrentBalance - (ClientMonthlyPaymentCreateDTO.ReceivedAmount ?? 0);

                    if (updCollectionAndBalance.CurrentBalance < 0)
                    {
                        _response.StatusCode = HttpStatusCode.NoContent;
                        _response.Result = null;
                        _response.IsSuccess = false;
                        _response.SuccessMessage = null;
                        _response.ErrorMessages = new List<string> { "You cannot pay in excess of " + updCollectionAndBalance.CurrentBalance + " for this period" };
                        return Ok(_response);
                    }

                    await _unitOfWork.CollectionAndBalances.UpdateAsync(updCollectionAndBalance);
                }else
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Error fetching Collection And Balances record" };
                    return Ok(_response);
                }
               
                ///

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<ClientMonthlyPaymentDTO>(ClientMonthlyPayment);
                _response.IsSuccess = true;
                _response.SuccessMessage = "ClientMonthly Payment record created and Account Ledger entered successuflly";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetClientMonthlyPayment", new { id = ClientMonthlyPayment.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

    }
}
