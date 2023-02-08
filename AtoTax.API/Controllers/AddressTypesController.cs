﻿using System;
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
    public class AddressTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IAddressTypeRepository _dbAddressType;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AddressTypesController(IAddressTypeRepository dbAddressType, IMapper mapper, AtoTaxDbContext context)
        {
            _dbAddressType = dbAddressType;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/AddressTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAddressTypes()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<AddressType> AddressTypesList = await _dbAddressType.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AddressTypeDTO>>(AddressTypesList);
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
                AddressType AddressType = await _dbAddressType.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AddressTypeDTO>(AddressType);
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

        // PUT: api/AddressTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateAddressType(int id, AddressTypeUpdateDTO AddressTypeUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == AddressTypeUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldAddressType = await _dbAddressType.GetAsync(u => u.Id == id, tracked: false);

                if (oldAddressType == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var AddressType = _mapper.Map<AddressType>(AddressTypeUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                AddressType.AddressTypeName = oldAddressType.AddressTypeName;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                AddressType.CreatedDate = oldAddressType.CreatedDate;

                await _dbAddressType.UpdateAsync(AddressType);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = AddressType;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/AddressTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAddressType(AddressTypeCreateDTO AddressTypeCreateDTO)
        {
            try
            {

                if (await _dbAddressType.GetAsync(u => u.AddressTypeName == AddressTypeCreateDTO.AddressTypeName) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
               
                var AddressType = _mapper.Map<AddressType>(AddressTypeCreateDTO);
                AddressType.CreatedDate= DateTime.UtcNow;
                await _dbAddressType.CreateAsync(AddressType);

                _response.Result = _mapper.Map<AddressTypeDTO>(AddressType);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetAddressType", new { id = AddressType.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
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
                    return BadRequest(_response);
                }
                var AddressType = await _dbAddressType.GetAsync(u => u.Id == id);
                if (AddressType == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbAddressType.RemoveAsync(AddressType);

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