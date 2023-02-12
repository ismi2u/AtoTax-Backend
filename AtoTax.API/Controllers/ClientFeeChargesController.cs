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

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ClientFeeCharges : ControllerBase
    {
        protected APIResponse _response;
        private readonly IClientFeeChargeRepository _dbClientFeeCharge;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ClientFeeCharges(IClientFeeChargeRepository dbClientFeeCharge, IMapper mapper, AtoTaxDbContext context)
        {
            _dbClientFeeCharge = dbClientFeeCharge;
            _mapper = mapper;
            this._response = new();
            _context = context;
        }

        // GET: api/ClientFeeCharges
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeCharges()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ClientFeeCharge> ClientFeeChargesList = await _dbClientFeeCharge.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ClientFeeChargeDTO>>(ClientFeeChargesList);
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

        // GET: api/ClientFeeCharges/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeCharge(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ClientFeeCharge ClientFeeCharge = await _dbClientFeeCharge.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ClientFeeChargeDTO>(ClientFeeCharge);
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

        // PUT: api/ClientFeeCharges/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateClientFeeCharge(Guid id, ClientFeeChargeUpdateDTO ClientFeeChargeUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == ClientFeeChargeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldClientFeeCharge = await _dbClientFeeCharge.GetAsync(u => u.Id == id, tracked: false);

                if (oldClientFeeCharge == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var ClientFeeCharge = _mapper.Map<ClientFeeCharge>(ClientFeeChargeUpdateDTO);

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ClientFeeCharge.CreatedDate = oldClientFeeCharge.CreatedDate;

                await _dbClientFeeCharge.UpdateAsync(ClientFeeCharge);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = ClientFeeCharge;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/ClientFeeCharges
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateClientFeeCharge(ClientFeeChargeCreateDTO ClientFeeChargeCreateDTO)
        {
            try
            {

                if (await _dbClientFeeCharge.GetAsync(u => u.GSTClientId == ClientFeeChargeCreateDTO.GSTClientId) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Client Fee Charge already Exists" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var ClientFeeCharge = _mapper.Map<ClientFeeCharge>(ClientFeeChargeCreateDTO);
                ClientFeeCharge.CreatedDate = DateTime.UtcNow;
                await _dbClientFeeCharge.CreateAsync(ClientFeeCharge);

                _response.Result = _mapper.Map<ClientFeeChargeDTO>(ClientFeeCharge);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetClientFeeCharge", new { id = ClientFeeCharge.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/ClientFeeCharges/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteClientFeeCharge(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var ClientFeeCharge = await _dbClientFeeCharge.GetAsync(u => u.Id == id);
                if (ClientFeeCharge == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbClientFeeCharge.RemoveAsync(ClientFeeCharge);

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
