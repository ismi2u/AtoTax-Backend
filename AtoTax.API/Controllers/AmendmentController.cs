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
using Azure;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="Admin")]
    public class AmendmentController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AmendmentController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/Amendments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendments()
        {

            List<string> includelist = new List<string>();
            includelist.Add("ApprovalStatusType");
            includelist.Add("GSTClient");
            includelist.Add("AmendType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<Amendment> AmendmentsList = await _unitOfWork.Amendments.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AmendmentDTO>>(AmendmentsList);
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

        // GET: api/Amendments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendment(Guid id)
        {


            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("AmendType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                Amendment Amendment = await _unitOfWork.Amendments.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AmendmentDTO>(Amendment);
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

       

        // POST: api/Amendments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAmendment(AmendmentCreateDTO AmendmentCreateDTO)
        {
            try
            {

                if (await _unitOfWork.Amendments.GetAsync(u => u.AmendTypeId == AmendmentCreateDTO.AmendTypeId
                && u.GSTClientId == AmendmentCreateDTO.GSTClientId) != null)
                {
                    _response.Result = AmendmentCreateDTO;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string>() { "Record already exists for Amendment Type and GST Client" };
                }
               
                var Amendment = _mapper.Map<Amendment>(AmendmentCreateDTO);
                Amendment.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.Amendments.CreateAsync(Amendment);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<AmendmentDTO>(Amendment);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Amendment created successfully";

                return CreatedAtAction("GetAmendment", new { id = Amendment.Id }, _response);
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

        // PUT: api/Amendments
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateAmendment(Guid id, AmendmentUpdateDTO AmendmentUpdateDTO)
        {

            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = AmendmentUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "Amendment modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == Guid.Empty || !(id == AmendmentUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = AmendmentUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Amendment modelstate invalid" };
                    return Ok(_response);
                }


                var oldAmendment = await _unitOfWork.Amendments.GetAsync(u => u.Id == id, tracked: false);

                if (oldAmendment == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Amendment modelstate invalid" };
                    return Ok(_response);
                }

                var Amendment = _mapper.Map<Amendment>(AmendmentUpdateDTO);

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                Amendment.CreatedDate = oldAmendment.CreatedDate;

                await _unitOfWork.Amendments.UpdateAsync(Amendment);

                await _unitOfWork.CompleteAsync();
                
                _response.Result = _mapper.Map<AmendmentDTO>(Amendment);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Amendment Updated"; ;
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

        // DELETE: api/Amendments/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteAmendment(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Amendment Id not found" };
                    return Ok(_response);
                }
                var Amendment = await _unitOfWork.Amendments.GetAsync(u => u.Id == id);
                if (Amendment == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Amendment not found" };
                    return Ok(_response);
                }

                await _unitOfWork.Amendments.RemoveAsync(Amendment);

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = Amendment;
                _response.IsSuccess = true;
                _response.SuccessMessage = "Amendment deleted";
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
