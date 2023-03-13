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
    //[Authorize(Roles="User")]
    public class ReturnFrequencyTypeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ReturnFrequencyTypeController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
           
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ReturnFrequencyTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetReturnFrequencyTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ReturnFrequencyType> ReturnFrequencyTypesList = await _unitOfWork.ReturnFrequencyTypes.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ReturnFrequencyTypeDTO>>(ReturnFrequencyTypesList);
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
        public async Task<ActionResult<APIResponse>> GetActiveServiceCategoriesForDD()
        {
            try
            {
                IEnumerable<ReturnFrequencyType> ReturnFrequencyTypesList = await _unitOfWork.ReturnFrequencyTypes.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ReturnFrequencyType>>(ReturnFrequencyTypesList);
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

        // GET: api/ReturnFrequencyTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetReturnFrequencyType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ReturnFrequencyType ReturnFrequencyType = await _unitOfWork.ReturnFrequencyTypes.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ReturnFrequencyTypeDTO>(ReturnFrequencyType);
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

        //// PUT: api/ReturnFrequencyTypes/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<APIResponse>> UpdateReturnFrequencyType(int id, ReturnFrequencyTypeUpdateDTO ReturnFrequencyTypeUpdateDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.Result = ReturnFrequencyTypeUpdateDTO;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string> { "ReturnFrequencyType modelstate invalid" };
        //        return Ok(_response);
        //    }

        //    try
        //    {
        //        if (id == 0 || !(id == ReturnFrequencyTypeUpdateDTO.Id))
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.Result = ReturnFrequencyTypeUpdateDTO;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "Update ReturnFrequencyType failed" };
        //            return Ok(_response);
        //        }


        //        var oldReturnFrequencyType = await _unitOfWork.ReturnFrequencyTypes.GetAsync(u => u.Id == id, tracked: false);

        //        if (oldReturnFrequencyType == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NoContent;
        //            _response.Result = ReturnFrequencyTypeUpdateDTO;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "ReturnFrequencyType data is Null" };
        //            return Ok(_response);
        //        }

        //        var ReturnFrequencyType = _mapper.Map<ReturnFrequencyType>(ReturnFrequencyTypeUpdateDTO);

        //        //// dont update the below field as they are not part of updateDTO  and hence will become null
        //        ReturnFrequencyType.CreatedDate = oldReturnFrequencyType.CreatedDate;
        //        ReturnFrequencyType.PreviousCharge = oldReturnFrequencyType.FixedCharge;

        //        await _unitOfWork.ReturnFrequencyTypes.UpdateAsync(ReturnFrequencyType);

        //        await _unitOfWork.CompleteAsync();
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = ReturnFrequencyType;
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "ReturnFrequencyType updated";
        //        _response.ErrorMessages = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = null;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string> { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}

        // POST: api/ReturnFrequencyTypes
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<APIResponse>> CreateReturnFrequencyType(ReturnFrequencyTypeCreateDTO ReturnFrequencyTypeCreateDTO)
        //{
        //    try
        //    {

        //        if (await _unitOfWork.ReturnFrequencyTypes.GetAsync(u => u.ServiceName == ReturnFrequencyTypeCreateDTO.ServiceName) != null)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.Result = ReturnFrequencyTypeCreateDTO;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "ReturnFrequencyType not found" };
        //            return Ok(_response);
        //        }
        //        var ReturnFrequencyType = _mapper.Map<ReturnFrequencyType>(ReturnFrequencyTypeCreateDTO);
        //        ReturnFrequencyType.PreviousCharge= ReturnFrequencyTypeCreateDTO.FixedCharge;
        //        await _unitOfWork.ReturnFrequencyTypes.CreateAsync(ReturnFrequencyType);

        //        await _unitOfWork.CompleteAsync();

        //        _response.StatusCode = HttpStatusCode.Created;
        //        _response.Result = _mapper.Map<ReturnFrequencyTypeDTO>(ReturnFrequencyType);
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "New ReturnFrequencyType created";
        //        _response.ErrorMessages = null;

        //        return CreatedAtAction("GetReturnFrequencyType", new { id = ReturnFrequencyType.Id }, _response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = null;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string> { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}

        // DELETE: api/ReturnFrequencyTypes/5
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<APIResponse>> DeleteReturnFrequencyType(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            _response.Result = null;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "ReturnFrequencyType Id not found" };
        //            return Ok(_response);
        //        }
        //        var ReturnFrequencyType = await _unitOfWork.ReturnFrequencyTypes.GetAsync(u => u.Id == id);
        //        if (ReturnFrequencyType == null)
        //        {
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            _response.Result = null;
        //            _response.IsSuccess = false;
        //            _response.SuccessMessage = null;
        //            _response.ErrorMessages = new List<string> { "ReturnFrequencyType not found" };
        //            return Ok(_response);
        //        }

        //        await _unitOfWork.ReturnFrequencyTypes.RemoveAsync(ReturnFrequencyType);

        //        await _unitOfWork.CompleteAsync();

        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = ReturnFrequencyType;
        //        _response.IsSuccess = true;
        //        _response.SuccessMessage = "ReturnFrequencyType deleted";
        //        _response.ErrorMessages = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.NoContent;
        //        _response.Result = null;
        //        _response.IsSuccess = false;
        //        _response.SuccessMessage = null;
        //        _response.ErrorMessages = new List<string> { ex.ToString() };
        //    }
        //    return Ok(_response);
        //}

    }
}
