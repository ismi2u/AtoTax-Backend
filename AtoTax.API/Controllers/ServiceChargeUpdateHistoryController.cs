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
using static AtoTax.Domain.DTOs.ServiceChargeUpdateHistoryCreateDTO;
using AtoTax.API.GenericRepository;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ServiceChargeUpdateHistoryController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ServiceChargeUpdateHistoryController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ServiceChargeUpdateHistory
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceChargeUpdateHistory()
        {
            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                IEnumerable<ServiceChargeUpdateHistory> ServiceChargeUpdateHistoryList = await _unitOfWork.ServiceChargeUpdateHistories.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ServiceChargeUpdateHistoryDTO>>(ServiceChargeUpdateHistoryList);
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

        // GET: api/ServiceChargeUpdateHistory/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceChargeUpdateHistory(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ServiceChargeUpdateHistory ServiceChargeUpdateHistory = await _unitOfWork.ServiceChargeUpdateHistories.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ServiceChargeUpdateHistoryDTO>(ServiceChargeUpdateHistory);
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
        /*
        // PUT: api/ServiceChargeUpdateHistory/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateServiceChargeUpdateHistory(Guid id, ServiceChargeUpdateHistoryUpdateDTO ServiceChargeUpdateHistoryUpdateDTO)
        {

            try
            {
                if (id == Guid.Empty || !(id == ServiceChargeUpdateHistoryUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldServiceChargeUpdateHistory = await _unitOfWork.ServiceChargeUpdateHistories.GetAsync(u => u.Id == id, tracked: false);

                if (oldServiceChargeUpdateHistory == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var ServiceChargeUpdateHistory = _mapper.Map<ServiceChargeUpdateHistory>(ServiceChargeUpdateHistoryUpdateDTO);

                ////// dont update the GSTIN number which is the Identity of the GST Client
                //ServiceChargeUpdateHistory.Media = oldServiceChargeUpdateHistory.Media;

                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //ServiceChargeUpdateHistory.CreatedDate = oldServiceChargeUpdateHistory.CreatedDate;

                await _unitOfWork.ServiceChargeUpdateHistories.UpdateAsync(ServiceChargeUpdateHistory);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = ServiceChargeUpdateHistory;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/ServiceChargeUpdateHistory
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateServiceChargeUpdateHistory(ServiceChargeUpdateHistoryCreateDTO ServiceChargeUpdateHistoryCreateDTO)
        {
            try
            {

                //if (await _dbServiceChargeUpdateHistory.GetAsync(u => u.Media == ServiceChargeUpdateHistoryCreateDTO.Media) != null)
                //{
                //    _response.ErrorMessages = new List<string>() { "ServiceChargeUpdateHistory already Exists"};
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return _response;
                //}
                var ServiceChargeUpdateHistory = _mapper.Map<ServiceChargeUpdateHistory>(ServiceChargeUpdateHistoryCreateDTO);
                ServiceChargeUpdateHistory.AmendedDate = DateTime.UtcNow;
                await _unitOfWork.ServiceChargeUpdateHistories.CreateAsync(ServiceChargeUpdateHistory);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<ServiceChargeUpdateHistoryDTO>(ServiceChargeUpdateHistory);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetServiceChargeUpdateHistory", new { id = ServiceChargeUpdateHistory.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/ServiceChargeUpdateHistory/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteServiceChargeUpdateHistory(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var ServiceChargeUpdateHistory = await _unitOfWork.ServiceChargeUpdateHistories.GetAsync(u => u.Id == id);
                if (ServiceChargeUpdateHistory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.ServiceChargeUpdateHistories.RemoveAsync(ServiceChargeUpdateHistory);

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
        */

    }
}
