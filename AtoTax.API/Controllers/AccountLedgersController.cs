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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="User")]
    public class AccountLedgersController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AccountLedgersController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/AccountLedger
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAccountLedger()
        {

            List<string> includelist = new List<string>();
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<AccountLedger> AccountLedgerList = await _unitOfWork.AccountLedgers.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AccountLedgerDTO>>(AccountLedgerList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() { ex.ToString()};
            }
            return Ok(_response);
        }

        // GET: api/AccountLedger/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAccountLedger(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                AccountLedger AccountLedger = await _unitOfWork.AccountLedgers.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AccountLedgerDTO>(AccountLedger);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }


        // POST: api/AccountLedger
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAccountLedger(AccountLedgerCreateDTO AccountLedgerCreateDTO)
        {
            if((AccountLedgerCreateDTO.IncomeAmount == 0 || AccountLedgerCreateDTO.IncomeAmount == null) && (AccountLedgerCreateDTO.ExpenseAmount == 0 || AccountLedgerCreateDTO.ExpenseAmount == null))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string>() { "Ledger entry should be Income Or Expense" };

            }

            try
            {

                var AccountLedger = _mapper.Map<AccountLedger>(AccountLedgerCreateDTO);


                if(AccountLedger.ExpenseAmount==0)
                {
                    AccountLedger.ExpenseAmount = null;
                }
                if (AccountLedger.IncomeAmount == 0)
                {
                    AccountLedger.IncomeAmount = null;
                }



                AccountLedger.TransactionDate = DateTime.UtcNow;
                AccountLedger.TransactionRecordedBy = User.Identity.Name;


                await _unitOfWork.AccountLedgers.CreateAsync(AccountLedger);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<AccountLedgerDTO>(AccountLedger);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Account Ledger data entered successfully";
                _response.ErrorMessages =null;

                return CreatedAtAction("GetAccountLedger", new { id = AccountLedger.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }
    }
}
