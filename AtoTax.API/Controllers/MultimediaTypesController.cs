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
    public class MultimediaTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public MultimediaTypesController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/MultimediaTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMultimediaTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<MultimediaType> MultimediaTypesList = await _unitOfWork.MultimediaTypes.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<MultimediaTypeDTO>>(MultimediaTypesList);
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

        // GET: api/MultimediaTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMultimediaType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                MultimediaType MultimediaType = await _unitOfWork.MultimediaTypes.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<MultimediaTypeDTO>(MultimediaType);
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

        // PUT: api/MultimediaTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateMultimediaType(int id, MultimediaTypeUpdateDTO MultimediaTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == MultimediaTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldMultimediaType = await _unitOfWork.MultimediaTypes.GetAsync(u => u.Id == id, tracked: false);

                if (oldMultimediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var MultimediaType = _mapper.Map<MultimediaType>(MultimediaTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                MultimediaType.Media = oldMultimediaType.Media;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                MultimediaType.CreatedDate = oldMultimediaType.CreatedDate;

                await _unitOfWork.MultimediaTypes.UpdateAsync(MultimediaType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = MultimediaType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/MultimediaTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateMultimediaType(MultimediaTypeCreateDTO MultimediaTypeCreateDTO)
        {
            try
            {

                if (await _unitOfWork.MultimediaTypes.GetAsync(u => u.Media == MultimediaTypeCreateDTO.Media) != null)
                {
                    _response.ErrorMessages = new List<string>() { "MultimediaType already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var MultimediaType = _mapper.Map<MultimediaType>(MultimediaTypeCreateDTO);
                MultimediaType.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.MultimediaTypes.CreateAsync(MultimediaType);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<MultimediaTypeDTO>(MultimediaType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetMultimediaType", new { id = MultimediaType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/MultimediaTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteMultimediaType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var MultimediaType = await _unitOfWork.MultimediaTypes.GetAsync(u => u.Id == id);
                if (MultimediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.MultimediaTypes.RemoveAsync(MultimediaType);

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
