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
    public class DefaultCharges : ControllerBase
    {
        protected APIResponse _response;
        private readonly IDefaultChargeRepository _dbDefaultCharge;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public DefaultCharges(IDefaultChargeRepository dbDefaultCharge, IMapper mapper, AtoTaxDbContext context)
        {
            _dbDefaultCharge = dbDefaultCharge;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/DefaultCharges
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDefaultCharges()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<DefaultCharge> DefaultChargesList = await _dbDefaultCharge.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<DefaultChargeDTO>>(DefaultChargesList);
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

        // GET: api/DefaultCharges/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDefaultCharge(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                DefaultCharge DefaultCharge = await _dbDefaultCharge.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<DefaultChargeDTO>(DefaultCharge);
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

        // PUT: api/DefaultCharges/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateDefaultCharge(int id, DefaultChargeUpdateDTO DefaultChargeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == DefaultChargeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldDefaultCharge = await _dbDefaultCharge.GetAsync(u => u.Id == id, tracked: false);

                if (oldDefaultCharge == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var DefaultCharge = _mapper.Map<DefaultCharge>(DefaultChargeUpdateDTO);

                            

                await _dbDefaultCharge.UpdateAsync(DefaultCharge);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = DefaultCharge;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/DefaultCharges
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateDefaultCharge(DefaultChargeCreateDTO DefaultChargeCreateDTO)
        {
            try
            {

                if (await _dbDefaultCharge.GetAsync(u => u.GSTClientServiceType == DefaultChargeCreateDTO.GSTClientServiceType) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Default Fee Charge already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var DefaultCharge = _mapper.Map<DefaultCharge>(DefaultChargeCreateDTO);
                //DefaultCharge.CreatedDate= DateTime.UtcNow;
                await _dbDefaultCharge.CreateAsync(DefaultCharge);

                _response.Result = _mapper.Map<DefaultChargeDTO>(DefaultCharge);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetDefaultCharge", new { id = DefaultCharge.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/DefaultCharges/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteDefaultCharge(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var DefaultCharge = await _dbDefaultCharge.GetAsync(u => u.Id == id);
                if (DefaultCharge == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbDefaultCharge.RemoveAsync(DefaultCharge);

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
