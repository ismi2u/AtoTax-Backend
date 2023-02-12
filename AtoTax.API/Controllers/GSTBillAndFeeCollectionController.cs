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
    public class GSTBillAndFeeCollectionController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public GSTBillAndFeeCollectionController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/GSTBillAndFeeCollection
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTBillAndFeeCollection> GSTBillAndFeeCollectionList = await _unitOfWork.GSTBillAndFeeCollections.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTBillAndFeeCollectionDTO>>(GSTBillAndFeeCollectionList);
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

        // GET: api/GSTBillAndFeeCollection/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTBillAndFeeCollection GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
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

        // PUT: api/GSTBillAndFeeCollection/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTBillAndFeeCollection(Guid id, GSTBillAndFeeCollectionUpdateDTO GSTBillAndFeeCollectionUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == GSTBillAndFeeCollectionUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldGSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionUpdateDTO);

                //// dont update the FilingType number which is the Identity of the FilingType
                //GSTBillAndFeeCollection.FilingType = oldGSTBillAndFeeCollection.FilingType;

                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //GSTBillAndFeeCollection.CreatedDate = oldGSTBillAndFeeCollection.CreatedDate;

                await _unitOfWork.GSTBillAndFeeCollections.UpdateAsync(GSTBillAndFeeCollection);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTBillAndFeeCollection;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/GSTBillAndFeeCollection
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTBillAndFeeCollection(GSTBillAndFeeCollectionCreateDTO GSTBillAndFeeCollectionCreateDTO)
        {
            try
            {

                //if (await _dbGSTBillAndFeeCollection.GetAsync(u => u.FilingType == GSTBillAndFeeCollectionCreateDTO.FilingType) != null)
                //{
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return _response;
                //}

                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionCreateDTO);
                //GSTBillAndFeeCollection.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.GSTBillAndFeeCollections.CreateAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetGSTBillAndFeeCollection", new { id = GSTBillAndFeeCollection.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/GSTBillAndFeeCollection/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTBillAndFeeCollection(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id);
                if (GSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.GSTBillAndFeeCollections.RemoveAsync(GSTBillAndFeeCollection);

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
