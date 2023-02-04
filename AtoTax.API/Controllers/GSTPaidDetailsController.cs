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
    public class GSTPaidDetailsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IGSTPaidDetailRepository _dbGSTPaidDetail;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public GSTPaidDetailsController(IGSTPaidDetailRepository dbGSTPaidDetail, IMapper mapper, AtoTaxDbContext context)
        {
            _dbGSTPaidDetail = dbGSTPaidDetail;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/GSTPaidDetails
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTPaidDetails()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTPaidDetail> GSTPaidDetailsList = await _dbGSTPaidDetail.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTPaidDetailDTO>>(GSTPaidDetailsList);
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

        // GET: api/GSTPaidDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTPaidDetail(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTPaidDetail GSTPaidDetail = await _dbGSTPaidDetail.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTPaidDetailDTO>(GSTPaidDetail);
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

        // PUT: api/GSTPaidDetails/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTPaidDetail(Guid id, GSTPaidDetailUpdateDTO GSTPaidDetailUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == GSTPaidDetailUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldGSTPaidDetail = await _dbGSTPaidDetail.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTPaidDetail == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var GSTPaidDetail = _mapper.Map<GSTPaidDetail>(GSTPaidDetailUpdateDTO);

                await _dbGSTPaidDetail.UpdateAsync(GSTPaidDetail);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTPaidDetail;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
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
                //    return _response;
                //}

                var GSTPaidDetail = _mapper.Map<GSTPaidDetail>(GSTPaidDetailCreateDTO);
                //GSTPaidDetail.CreatedDate= DateTime.UtcNow;
                await _dbGSTPaidDetail.CreateAsync(GSTPaidDetail);

                _response.Result = _mapper.Map<GSTPaidDetailDTO>(GSTPaidDetail);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetGSTPaidDetail", new { id = GSTPaidDetail.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
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
                    return BadRequest(_response);
                }
                var GSTPaidDetail = await _dbGSTPaidDetail.GetAsync(u => u.Id == id);
                if (GSTPaidDetail == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbGSTPaidDetail.RemoveAsync(GSTPaidDetail);

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
