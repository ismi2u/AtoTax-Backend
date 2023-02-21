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
    public class ClientFeeMapsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ClientFeeMapsController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/ClientFeeMaps
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeMaps()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ClientFeeMap> ClientFeeMapsList = await _unitOfWork.ClientFeeMaps.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ClientFeeMapDTO>>(ClientFeeMapsList);
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

        // GET: api/ClientFeeMaps/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeMap(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ClientFeeMap ClientFeeMap = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ClientFeeMapDTO>(ClientFeeMap);
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

        // PUT: api/ClientFeeMaps/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateClientFeeMap(Guid id, ClientFeeMapUpdateDTO ClientFeeMapUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == ClientFeeMapUpdateDTO.Id) || ClientFeeMapUpdateDTO.GSTClientId == Guid.Empty || ClientFeeMapUpdateDTO.ServiceCategoryId == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Data error! Check Update data."};
                    return BadRequest(_response);
                }


                var oldClientFeeMap = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.Id == id, tracked: false);

                if (oldClientFeeMap == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var ClientFeeMap = _mapper.Map<ClientFeeMap>(ClientFeeMapUpdateDTO);

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ClientFeeMap.CreatedDate = oldClientFeeMap.CreatedDate;
                await _unitOfWork.ClientFeeMaps.UpdateAsync(ClientFeeMap);

                //create a new record in ServiceChargeUpdateHistory table to capture the update history
                ServiceChargeUpdateHistory serviceChargeUpdateHistory = _mapper.Map<ServiceChargeUpdateHistory>(ClientFeeMapUpdateDTO);
                serviceChargeUpdateHistory.AmendedDate = DateTime.UtcNow;
                serviceChargeUpdateHistory.PreviousRate = oldClientFeeMap.DefaultCharge;
                serviceChargeUpdateHistory.NewRate = ClientFeeMapUpdateDTO.DefaultCharge;

                await _unitOfWork.ServiceChargeUpdateHistories.CreateAsync(serviceChargeUpdateHistory);
                _response.StatusCode = HttpStatusCode.Created;

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = ClientFeeMap;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //// POST: api/ClientFeeMaps
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> CreateClientFeeMap(ClientFeeMapCreateDTO ClientFeeMapCreateDTO)
        //{
        //    try
        //    {

        //        if (await _unitOfWork.ClientFeeMaps.GetAsync(u => u.GSTClientId == ClientFeeMapCreateDTO.GSTClientId) != null)
        //        {
        //            _response.ErrorMessages = new List<string>() { "Client Fee Charge already Exists" };
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return _response;
        //        }
        //        var ClientFeeMap = _mapper.Map<ClientFeeMap>(ClientFeeMapCreateDTO);
        //        ClientFeeMap.CreatedDate = DateTime.UtcNow;
        //        await _unitOfWork.ClientFeeMaps.CreateAsync(ClientFeeMap);


        //        await _unitOfWork.CompleteAsync();
        //        _response.Result = _mapper.Map<ClientFeeMapDTO>(ClientFeeMap);
        //        _response.StatusCode = HttpStatusCode.Created;

        //        return CreatedAtAction("GetClientFeeMap", new { id = ClientFeeMap.Id }, _response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        //// DELETE: api/ClientFeeMaps/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<APIResponse>> DeleteClientFeeMap(Guid id)
        //{
        //    try
        //    {
        //        if (id == Guid.Empty)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var ClientFeeMap = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.Id == id);
        //        if (ClientFeeMap == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            return NotFound(_response);
        //        }

        //        await _unitOfWork.ClientFeeMaps.RemoveAsync(ClientFeeMap);

        //        await _unitOfWork.CompleteAsync();
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

    }
}
