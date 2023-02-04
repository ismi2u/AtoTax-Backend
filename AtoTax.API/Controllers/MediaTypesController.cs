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
    public class MediaTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMediaTypeRepository _dbMediaType;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public MediaTypesController(IMediaTypeRepository dbMediaType, IMapper mapper, AtoTaxDbContext context)
        {
            _dbMediaType = dbMediaType;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/MediaTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMediaTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<MediaType> MediaTypesList = await _dbMediaType.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<MediaTypeDTO>>(MediaTypesList);
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

        // GET: api/MediaTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMediaType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                MediaType MediaType = await _dbMediaType.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<MediaTypeDTO>(MediaType);
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

        // PUT: api/MediaTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateMediaType(int id, MediaTypeUpdateDTO MediaTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == MediaTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldMediaType = await _dbMediaType.GetAsync(u => u.Id == id, tracked: false);

                if (oldMediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var MediaType = _mapper.Map<MediaType>(MediaTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                MediaType.Media = oldMediaType.Media;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                MediaType.CreatedDate = oldMediaType.CreatedDate;

                await _dbMediaType.UpdateAsync(MediaType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = MediaType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/MediaTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateMediaType(MediaTypeCreateDTO MediaTypeCreateDTO)
        {
            try
            {

                if (await _dbMediaType.GetAsync(u => u.Media == MediaTypeCreateDTO.Media) != null)
                {
                    _response.ErrorMessages = new List<string>() { "MediaType already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var MediaType = _mapper.Map<MediaType>(MediaTypeCreateDTO);
                MediaType.CreatedDate= DateTime.UtcNow;
                await _dbMediaType.CreateAsync(MediaType);

                _response.Result = _mapper.Map<MediaTypeDTO>(MediaType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetMediaType", new { id = MediaType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/MediaTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteMediaType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var MediaType = await _dbMediaType.GetAsync(u => u.Id == id);
                if (MediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbMediaType.RemoveAsync(MediaType);

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
