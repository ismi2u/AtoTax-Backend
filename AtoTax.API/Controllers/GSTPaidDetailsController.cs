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
using System.Security.Claims;
using AtoTax.API.Authentication;
using Microsoft.AspNetCore.Identity;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles="User")]
    public class GSTPaidDetailsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;
      

        public GSTPaidDetailsController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
            
        }

        // GET: api/GSTPaidDetails
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTPaidDetails()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTPaidDetail> GSTPaidDetailsList = await _unitOfWork.GSTPaidDetails.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTPaidDetailDTO>>(GSTPaidDetailsList);
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

        // GET: api/GSTPaidDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTPaidDetail(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            includelist.Add("PaymentType");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTPaidDetail GSTPaidDetail = await _unitOfWork.GSTPaidDetails.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTPaidDetailDTO>(GSTPaidDetail);
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

        // PUT: api/GSTPaidDetails/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTPaidDetail(Guid id, GSTPaidDetailUpdateDTO GSTPaidDetailUpdateDTO)
        {
           

            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = GSTPaidDetailUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "GSTPaidDetail modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == Guid.Empty || !(id == GSTPaidDetailUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldGSTPaidDetail = await _unitOfWork.GSTPaidDetails.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTPaidDetail == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = GSTPaidDetailUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTPaidDetail data is Null" };
                    return Ok(_response);
                }

                var GSTPaidDetail = _mapper.Map<GSTPaidDetail>(GSTPaidDetailUpdateDTO);

                await _unitOfWork.GSTPaidDetails.UpdateAsync(GSTPaidDetail);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return Ok(_response);
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTPaidDetail;
                return Ok(_response);
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

        // POST: api/GSTPaidDetails
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTPaidDetail(GSTPaidDetailCreateDTO GSTPaidDetailCreateDTO)
        {
            try
            {

                //if (await _dbGSTPaidDetail.GetAsync(u => u.FilingType == GSTPaidDetailCreateDTO.FilingType) != null)
                //{
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return Ok(_response);
                //}

                var GSTPaidDetail = _mapper.Map<GSTPaidDetail>(GSTPaidDetailCreateDTO);
                //GSTPaidDetail.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.GSTPaidDetails.CreateAsync(GSTPaidDetail);

                await _unitOfWork.CompleteAsync();

                _response.Result = _mapper.Map<GSTPaidDetailDTO>(GSTPaidDetail);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.SuccessMessage = "New Address type created";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetGSTPaidDetail", new { id = GSTPaidDetail.Id }, _response);
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

        // DELETE: api/GSTPaidDetails/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTPaidDetail(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTPaidDetail Id not found" };
                    return Ok(_response);
                }
                var GSTPaidDetail = await _unitOfWork.GSTPaidDetails.GetAsync(u => u.Id == id);
                if (GSTPaidDetail == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTPaidDetail not found" };
                    return Ok(_response);
                }

                await _unitOfWork.GSTPaidDetails.RemoveAsync(GSTPaidDetail);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTPaidDetail;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTPaidDetail deleted";
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

    }
}
