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
    [Authorize(Roles = "Admin")]
    public class GSTFilingTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public GSTFilingTypesController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/GSTFilingTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTFilingTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTFilingType> GSTFilingTypesList = await _unitOfWork.GSTFilingTypes.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTFilingTypeDTO>>(GSTFilingTypesList);
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveGSTFilingTypesForDD()
        {
            try
            {
                IEnumerable<GSTFilingType> GSTFilingTypesList = await _unitOfWork.GSTFilingTypes.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ActiveGSTFilingTypeForDD>>(GSTFilingTypesList);
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

        // GET: api/GSTFilingTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTFilingType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTFilingType GSTFilingType = await _unitOfWork.GSTFilingTypes.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTFilingTypeDTO>(GSTFilingType);
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

        // PUT: api/GSTFilingTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTFilingType(int id, GSTFilingTypeUpdateDTO GSTFilingTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == GSTFilingTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldGSTFilingType = await _unitOfWork.GSTFilingTypes.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTFilingType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var GSTFilingType = _mapper.Map<GSTFilingType>(GSTFilingTypeUpdateDTO);

                //// dont update the FilingType number which is the Identity of the FilingType
                GSTFilingType.FilingType = oldGSTFilingType.FilingType;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                GSTFilingType.CreatedDate = oldGSTFilingType.CreatedDate;

                await _unitOfWork.GSTFilingTypes.UpdateAsync(GSTFilingType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTFilingType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/GSTFilingTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTFilingType(GSTFilingTypeCreateDTO GSTFilingTypeCreateDTO)
        {
            try
            {

                if (await _unitOfWork.GSTFilingTypes.GetAsync(u => u.FilingType == GSTFilingTypeCreateDTO.FilingType) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }

                var GSTFilingType = _mapper.Map<GSTFilingType>(GSTFilingTypeCreateDTO);
                GSTFilingType.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.GSTFilingTypes.CreateAsync(GSTFilingType);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<GSTFilingTypeDTO>(GSTFilingType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetGSTFilingType", new { id = GSTFilingType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/GSTFilingTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTFilingType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var GSTFilingType = await _unitOfWork.GSTFilingTypes.GetAsync(u => u.Id == id);
                if (GSTFilingType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.GSTFilingTypes.RemoveAsync(GSTFilingType);

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
