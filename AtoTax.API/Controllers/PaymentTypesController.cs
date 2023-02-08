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
    public class PaymentTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IPaymentTypeRepository _dbPaymentType;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public PaymentTypesController(IPaymentTypeRepository dbPaymentType, IMapper mapper, AtoTaxDbContext context)
        {
            _dbPaymentType = dbPaymentType;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPaymentTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<PaymentType> PaymentTypesList = await _dbPaymentType.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<PaymentTypeDTO>>(PaymentTypesList);
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

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetPaymentType(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                PaymentType PaymentType = await _dbPaymentType.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<PaymentTypeDTO>(PaymentType);
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

        // PUT: api/PaymentTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdatePaymentType(int id, PaymentTypeUpdateDTO PaymentTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == PaymentTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldPaymentType = await _dbPaymentType.GetAsync(u => u.Id == id, tracked: false);

                if (oldPaymentType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var PaymentType = _mapper.Map<PaymentType>(PaymentTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
               // PaymentType.PaymentMethod = oldPaymentType.PaymentMethod;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                PaymentType.CreatedDate = oldPaymentType.CreatedDate;

                await _dbPaymentType.UpdateAsync(PaymentType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = PaymentType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/PaymentTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreatePaymentType(PaymentTypeCreateDTO PaymentTypeCreateDTO)
        {
            try
            {

                if (await _dbPaymentType.GetAsync(u => u.PaymentMethod == PaymentTypeCreateDTO.PaymentMethod) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Payment Type already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var PaymentType = _mapper.Map<PaymentType>(PaymentTypeCreateDTO);
                PaymentType.CreatedDate= DateTime.UtcNow;
                await _dbPaymentType.CreateAsync(PaymentType);

                _response.Result = _mapper.Map<PaymentTypeDTO>(PaymentType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetPaymentType", new { id = PaymentType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/PaymentTypes/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeletePaymentType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var PaymentType = await _dbPaymentType.GetAsync(u => u.Id == id);
                if (PaymentType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbPaymentType.RemoveAsync(PaymentType);

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
