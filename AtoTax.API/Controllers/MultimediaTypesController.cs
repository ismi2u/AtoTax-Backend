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
    [Authorize(Roles="User")]
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
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveMultimediaTypesForDD()
        {
            try
            {
                IEnumerable<MultimediaType> MultimediaTypesList = await _unitOfWork.MultimediaTypes.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ActiveMultimediaTypeForDD>>(MultimediaTypesList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.Message.ToString() };
            }
            return Ok(_response);
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
                _response.IsSuccess = true;
                _response.SuccessMessage = null;
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.Result = null;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }

        // PUT: api/MultimediaTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateMultimediaType(int id, MultimediaTypeUpdateDTO MultimediaTypeUpdateDTO)
        {

            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = MultimediaTypeUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "MultimediaType modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == 0 || !(id == MultimediaTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = MultimediaTypeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update MultimediaType failed" };
                    return Ok(_response);
                }


                var oldMultimediaType = await _unitOfWork.MultimediaTypes.GetAsync(u => u.Id == id, tracked: false);

                if (oldMultimediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = MultimediaTypeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "MultimediaType data is Null" };
                    return Ok(_response);
                }

                var MultimediaType = _mapper.Map<MultimediaType>(MultimediaTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                MultimediaType.Media = oldMultimediaType.Media;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                MultimediaType.CreatedDate = oldMultimediaType.CreatedDate;

                await _unitOfWork.MultimediaTypes.UpdateAsync(MultimediaType);

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = MultimediaType;
                _response.IsSuccess = true;
                _response.SuccessMessage = "MultimediaType updated";
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
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
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = MultimediaTypeCreateDTO;
                    _response.IsSuccess = true;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "MultimediaType not found" };
                    return Ok(_response);
                }
                var MultimediaType = _mapper.Map<MultimediaType>(MultimediaTypeCreateDTO);
                MultimediaType.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.MultimediaTypes.CreateAsync(MultimediaType);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<MultimediaTypeDTO>(MultimediaType);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New MultimediaType created";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetMultimediaType", new { id = MultimediaType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
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
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "MultimediaType Id not found" };
                    return Ok(_response);
                }
                var MultimediaType = await _unitOfWork.MultimediaTypes.GetAsync(u => u.Id == id);
                if (MultimediaType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "MultimediaType not found" };
                    return Ok(_response);
                }

                await _unitOfWork.MultimediaTypes.RemoveAsync(MultimediaType);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = MultimediaType;
                _response.IsSuccess = true;
                _response.SuccessMessage = "MultimediaType deleted";
                _response.ErrorMessages = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = null;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

    }
}
