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
using AtoTax.API.Repository;
using AtoTax.API.Repository.IRepository;
using System.Net;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GSTClientsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IGSTClientRepository _dbGSTClient;
        private readonly IMapper _mapper;

        public GSTClientsController(IGSTClientRepository dbGSTClient, IMapper mapper)
        {
            _dbGSTClient = dbGSTClient;
            _mapper = mapper;
            this._response= new();
        }

        // GET: api/GSTClients
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClients()
        {
            try
            {
                IEnumerable<GSTClient> GSTClientsList = await _dbGSTClient.GetAllAsync();

                _response.Result = _mapper.Map<IEnumerable<GSTClientDTO>>(GSTClientsList);
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

        // GET: api/GSTClients/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClient(Guid id)
        {

            try
            {
                GSTClient GSTClient = await _dbGSTClient.GetAsync(u => u.Id == id);


                _response.Result = _mapper.Map<GSTClientDTO>(GSTClient);
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

        // PUT: api/GSTClients/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTClient(Guid id, GSTClientUpdateDTO gstClientUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == gstClientUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldgstclient = await _dbGSTClient.GetAsync(u => u.Id == id, tracked: false);

                if (oldgstclient == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var gstClient = _mapper.Map<GSTClient>(gstClientUpdateDTO);

                // dont update the GSTIN number which is the Identity of the GST Client
                gstClient.GSTIN = oldgstclient.GSTIN;

                // dont update the below field as they are not part of updateDTO  and hence will become null
                gstClient.CreatedOn = oldgstclient.CreatedOn;

                await _dbGSTClient.UpdateAsync(gstClient);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = gstClient;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/GSTClients
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTClient(GSTClientCreateDTO gstClientCreateDTO)
        {
            try
            {

                if (await _dbGSTClient.GetAsync(u => u.GSTIN == gstClientCreateDTO.GSTIN) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                if (await _dbGSTClient.GetAsync(u => u.ProprietorName == gstClientCreateDTO.ProprietorName) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = gstClientCreateDTO;
                    return _response;
                }
                var gstClient = _mapper.Map<GSTClient>(gstClientCreateDTO);
                gstClient.CreatedOn= DateTime.UtcNow;
                await _dbGSTClient.CreateAsync(gstClient);

                _response.Result = _mapper.Map<GSTClientDTO>(gstClient);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetGSTClient", new { id = gstClient.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/GSTClients/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTClient(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var gstClient = await _dbGSTClient.GetAsync(u => u.Id == id);
                if (gstClient == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbGSTClient.RemoveAsync(gstClient);

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
