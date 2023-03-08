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
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Azure;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="User")]
    public class AddressTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AddressTypesController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/AddressTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAddressTypes([FromQuery] int pageSize = 0, int pageNumber = 1)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<AddressType> AddressTypesList = await _unitOfWork.AddressTypes.GetAllAsync(null, pageSize:pageSize, pageNumber:pageNumber, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AddressTypeDTO>>(AddressTypesList);
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

        // GET: api/GetActiveAddressTypesForDD
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveAddressTypesForDD([FromQuery] int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<AddressType> AddressTypesList = await _unitOfWork.AddressTypes.GetAllAsync(a=> a.StatusId== (int)EStatus.active, pageSize: pageSize, pageNumber: pageNumber);

                _response.Result = _mapper.Map<IEnumerable<ActiveAddressTypeForDD>>(AddressTypesList);
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

        // GET: api/AddressTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAddressType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                AddressType AddressType = await _unitOfWork.AddressTypes.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AddressTypeDTO>(AddressType);
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

        // PUT: api/AddressTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateAddressType(int id, AddressTypeUpdateDTO AddressTypeUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = AddressTypeUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "AddressType modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == 0 || !(id == AddressTypeUpdateDTO.Id))
                {
                    
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = AddressTypeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update AddressType failed" };
                    return Ok(_response);
                }


                var oldAddressType = await _unitOfWork.AddressTypes.GetAsync(u => u.Id == id, tracked: false);

                if (oldAddressType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = AddressTypeUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "AddressType data is Null" };
                    return Ok(_response);
                }

                var AddressType = _mapper.Map<AddressType>(AddressTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                AddressType.AddressTypeName = oldAddressType.AddressTypeName;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                AddressType.CreatedDate = oldAddressType.CreatedDate;

               AddressType addressType =  await _unitOfWork.AddressTypes.UpdateAsync(AddressType);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = AddressType;
                _response.IsSuccess = true;
                _response.SuccessMessage = "AddressType updated";
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

        // POST: api/AddressTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAddressType(AddressTypeCreateDTO AddressTypeCreateDTO)
        {
            try
            {

                if (await _unitOfWork.AddressTypes.GetAsync(u => u.AddressTypeName == AddressTypeCreateDTO.AddressTypeName) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = AddressTypeCreateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "AddressType not found" };
                    return Ok(_response);
                }
               
                var AddressType = _mapper.Map<AddressType>(AddressTypeCreateDTO);
                AddressType.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.AddressTypes.CreateAsync(AddressType);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<AddressTypeDTO>(AddressType);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New Address type created";
                _response.ErrorMessages = null;
 
                return CreatedAtAction("GetAddressType", new { id = AddressType.Id }, _response);
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

        // DELETE: api/AddressTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteAddressType(int id)
        {
            try
            {
                if (id == 0)
                {

                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "AddressType Id not found" };
                    return Ok(_response);
                   
                }
                var AddressType = await _unitOfWork.AddressTypes.GetAsync(u => u.Id == id);
                if (AddressType == null)
                {

                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "AddressType not found" };
                    return Ok(_response);
                }

                await _unitOfWork.AddressTypes.RemoveAsync(AddressType);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = AddressType;
                _response.IsSuccess = true;
                _response.SuccessMessage = "AddressType deleted";
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
