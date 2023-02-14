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
    public class FeeCollectionLedgersController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public FeeCollectionLedgersController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/FeeCollectionLedger
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetFeeCollectionLedger()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("AddressType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<FeeCollectionLedger> FeeCollectionLedgerList = await _unitOfWork.FeeCollectionLedgers.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<FeeCollectionLedgerDTO>>(FeeCollectionLedgerList);
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

        // GET: api/FeeCollectionLedger/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetFeeCollectionLedger(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("AddressType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                FeeCollectionLedger FeeCollectionLedger = await _unitOfWork.FeeCollectionLedgers.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<FeeCollectionLedgerDTO>(FeeCollectionLedger);
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

        // PUT: api/FeeCollectionLedger/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateFeeCollectionLedger(Guid id, FeeCollectionLedgerUpdateDTO FeeCollectionLedgerUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == FeeCollectionLedgerUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldFeeCollectionLedger = await _unitOfWork.FeeCollectionLedgers.GetAsync(u => u.Id == id, tracked: false);

                if (oldFeeCollectionLedger == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var FeeCollectionLedger = _mapper.Map<FeeCollectionLedger>(FeeCollectionLedgerUpdateDTO);

                //// dont update the JobRole number which is the Identity of the GST Client
                FeeCollectionLedger.GSTClientId = oldFeeCollectionLedger.GSTClientId;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ///FeeCollectionLedger.CreatedDate = oldFeeCollectionLedger.CreatedDate;

                await _unitOfWork.FeeCollectionLedgers.UpdateAsync(FeeCollectionLedger);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = FeeCollectionLedger;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/FeeCollectionLedger
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateFeeCollectionLedger(FeeCollectionLedgerCreateDTO FeeCollectionLedgerCreateDTO)
        {
            try
            {

                //if (await _dbFeeCollectionLedger.GetAsync(u => u.GSTClientId == FeeCollectionLedgerCreateDTO.GSTClientId
                //&& u.AddressTypeId == FeeCollectionLedgerCreateDTO.AddressTypeId) != null)
                //{
                //    _response.ErrorMessages = new List<string>() { "Duplicate for address Type for GST Client not allowed"};
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return _response;
                //}
                var FeeCollectionLedger = _mapper.Map<FeeCollectionLedger>(FeeCollectionLedgerCreateDTO);
                //FeeCollectionLedger.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.FeeCollectionLedgers.CreateAsync(FeeCollectionLedger);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<FeeCollectionLedgerDTO>(FeeCollectionLedger);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetFeeCollectionLedger", new { id = FeeCollectionLedger.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/FeeCollectionLedger/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteFeeCollectionLedger(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var FeeCollectionLedger = await _unitOfWork.FeeCollectionLedgers.GetAsync(u => u.Id == id);
                if (FeeCollectionLedger == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.FeeCollectionLedgers.RemoveAsync(FeeCollectionLedger);

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
