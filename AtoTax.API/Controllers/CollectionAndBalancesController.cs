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
    [Authorize(Roles = "User, Admin")]
    public class CollectionAndBalancesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public CollectionAndBalancesController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/CollectionAndBalances
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCollectionAndBalances()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<CollectionAndBalance> CollectionAndBalancesList = await _unitOfWork.CollectionAndBalances.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<CollectionAndBalanceDTO>>(CollectionAndBalancesList);
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

        // GET: api/CollectionAndBalances/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCollectionAndBalance(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                CollectionAndBalance CollectionAndBalance = await _unitOfWork.CollectionAndBalances.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<CollectionAndBalanceDTO>(CollectionAndBalance);
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

        // PUT: api/CollectionAndBalances/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateCollectionAndBalance(Guid id, CollectionAndBalanceUpdateDTO CollectionAndBalanceUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == CollectionAndBalanceUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldCollectionAndBalance = await _unitOfWork.CollectionAndBalances.GetAsync(u => u.Id == id, tracked: false);

                if (oldCollectionAndBalance == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var CollectionAndBalance = _mapper.Map<CollectionAndBalance>(CollectionAndBalanceUpdateDTO);

                await _unitOfWork.CollectionAndBalances.UpdateAsync(CollectionAndBalance);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = CollectionAndBalance;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/CollectionAndBalances
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateCollectionAndBalance(CollectionAndBalanceCreateDTO CollectionAndBalanceCreateDTO)
        {
            try
            {

                //if (await _dbCollectionAndBalance.GetAsync(u => u.FilingType == CollectionAndBalanceCreateDTO.FilingType) != null)
                //{
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return _response;
                //}

                var CollectionAndBalance = _mapper.Map<CollectionAndBalance>(CollectionAndBalanceCreateDTO);
                //CollectionAndBalance.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.CollectionAndBalances.CreateAsync(CollectionAndBalance);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<CollectionAndBalanceDTO>(CollectionAndBalance);
                _response.StatusCode = HttpStatusCode.Created;


                return CreatedAtAction("GetCollectionAndBalance", new { id = CollectionAndBalance.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/CollectionAndBalances/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteCollectionAndBalance(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var CollectionAndBalance = await _unitOfWork.CollectionAndBalances.GetAsync(u => u.Id == id);
                if (CollectionAndBalance == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.CollectionAndBalances.RemoveAsync(CollectionAndBalance);

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
