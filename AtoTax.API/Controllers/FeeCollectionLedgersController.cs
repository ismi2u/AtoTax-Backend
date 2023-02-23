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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountsLedgersController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AccountsLedgersController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/AccountsLedger
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAccountsLedger()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("AddressType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<AccountsLedger> AccountsLedgerList = await _unitOfWork.AccountsLedgers.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AccountsLedgerDTO>>(AccountsLedgerList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() { ex.ToString()};
            }
            return _response;
        }

        // GET: api/AccountsLedger/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAccountsLedger(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("AddressType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                AccountsLedger AccountsLedger = await _unitOfWork.AccountsLedgers.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AccountsLedgerDTO>(AccountsLedger);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
           
        }

        // PUT: api/AccountsLedger/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateAccountsLedger(Guid id, AccountsLedgerUpdateDTO AccountsLedgerUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == AccountsLedgerUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldAccountsLedger = await _unitOfWork.AccountsLedgers.GetAsync(u => u.Id == id, tracked: false);

                if (oldAccountsLedger == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var AccountsLedger = _mapper.Map<AccountsLedger>(AccountsLedgerUpdateDTO);

                //// dont update the JobRole number which is the Identity of the GST Client
                AccountsLedger.GSTClientId = oldAccountsLedger.GSTClientId;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ///AccountsLedger.CreatedDate = oldAccountsLedger.CreatedDate;

                await _unitOfWork.AccountsLedgers.UpdateAsync(AccountsLedger);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = AccountsLedger;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/AccountsLedger
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAccountsLedger(AccountsLedgerCreateDTO AccountsLedgerCreateDTO)
        {
            try
            {

                //if (await _dbAccountsLedger.GetAsync(u => u.GSTClientId == AccountsLedgerCreateDTO.GSTClientId
                //&& u.AddressTypeId == AccountsLedgerCreateDTO.AddressTypeId) != null)
                //{
                //    _response.ErrorMessages = new List<string>() { "Duplicate for address Type for GST Client not allowed"};
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return _response;
                //}
                var AccountsLedger = _mapper.Map<AccountsLedger>(AccountsLedgerCreateDTO);
                //AccountsLedger.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.AccountsLedgers.CreateAsync(AccountsLedger);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<AccountsLedgerDTO>(AccountsLedger);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetAccountsLedger", new { id = AccountsLedger.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/AccountsLedger/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteAccountsLedger(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var AccountsLedger = await _unitOfWork.AccountsLedgers.GetAsync(u => u.Id == id);
                if (AccountsLedger == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.AccountsLedgers.RemoveAsync(AccountsLedger);

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
