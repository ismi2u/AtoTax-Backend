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
    public class AmendTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IAmendTypeRepository _dbAmendType;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AmendTypesController(IAmendTypeRepository dbAmendType, IMapper mapper, AtoTaxDbContext context)
        {
            _dbAmendType = dbAmendType;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/AmendTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<AmendType> AmendTypesList = await _dbAmendType.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AmendTypeDTO>>(AmendTypesList);
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

        // GET: api/AmendTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                AmendType AmendType = await _dbAmendType.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AmendTypeDTO>(AmendType);
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

        // PUT: api/AmendTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateAmendType(int id, AmendTypeUpdateDTO AmendTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == AmendTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldAmendType = await _dbAmendType.GetAsync(u => u.Id == id, tracked: false);

                if (oldAmendType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var AmendType = _mapper.Map<AmendType>(AmendTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                AmendType.AmendTypeName = oldAmendType.AmendTypeName;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                AmendType.CreatedDate = oldAmendType.CreatedDate;

                await _dbAmendType.UpdateAsync(AmendType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = AmendType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/AmendTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAmendType(AmendTypeCreateDTO AmendTypeCreateDTO)
        {
            try
            {

                if (await _dbAmendType.GetAsync(u => u.AmendTypeName == AmendTypeCreateDTO.AmendTypeName) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
               
                var AmendType = _mapper.Map<AmendType>(AmendTypeCreateDTO);
                AmendType.CreatedDate= DateTime.UtcNow;
                await _dbAmendType.CreateAsync(AmendType);

                _response.Result = _mapper.Map<AmendTypeDTO>(AmendType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetAmendType", new { id = AmendType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/AmendTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteAmendType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var AmendType = await _dbAmendType.GetAsync(u => u.Id == id);
                if (AmendType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbAmendType.RemoveAsync(AmendType);

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
