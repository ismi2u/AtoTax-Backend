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
    public class GSTClientAddressExtensionsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IGSTClientAddressExtensionRepository _dbGSTClientAddressExtension;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public GSTClientAddressExtensionsController(IGSTClientAddressExtensionRepository dbGSTClientAddressExtension, IMapper mapper, AtoTaxDbContext context)
        {
            _dbGSTClientAddressExtension = dbGSTClientAddressExtension;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/GSTClientAddressExtension
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClientAddressExtension()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTClientAddressExtension> GSTClientAddressExtensionList = await _dbGSTClientAddressExtension.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTClientAddressExtensionDTO>>(GSTClientAddressExtensionList);
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

        // GET: api/GSTClientAddressExtension/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClientAddressExtension(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTClientAddressExtension GSTClientAddressExtension = await _dbGSTClientAddressExtension.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTClientAddressExtensionDTO>(GSTClientAddressExtension);
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

        // PUT: api/GSTClientAddressExtension/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTClientAddressExtension(int id, GSTClientAddressExtensionUpdateDTO GSTClientAddressExtensionUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == GSTClientAddressExtensionUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldGSTClientAddressExtension = await _dbGSTClientAddressExtension.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTClientAddressExtension == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var GSTClientAddressExtension = _mapper.Map<GSTClientAddressExtension>(GSTClientAddressExtensionUpdateDTO);

                //// dont update the JobRole number which is the Identity of the GST Client
                GSTClientAddressExtension.GSTClientId = oldGSTClientAddressExtension.GSTClientId;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                GSTClientAddressExtension.CreatedDate = oldGSTClientAddressExtension.CreatedDate;

                await _dbGSTClientAddressExtension.UpdateAsync(GSTClientAddressExtension);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTClientAddressExtension;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/GSTClientAddressExtension
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTClientAddressExtension(GSTClientAddressExtensionCreateDTO GSTClientAddressExtensionCreateDTO)
        {
            try
            {

                if (await _dbGSTClientAddressExtension.GetAsync(u => u.GSTClientId == GSTClientAddressExtensionCreateDTO.GSTClientId
                && u.AddressTypeId == GSTClientAddressExtensionCreateDTO.AddressTypeId) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Duplicate for address Type for GST Client not allowed"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var GSTClientAddressExtension = _mapper.Map<GSTClientAddressExtension>(GSTClientAddressExtensionCreateDTO);
                GSTClientAddressExtension.CreatedDate= DateTime.UtcNow;
                await _dbGSTClientAddressExtension.CreateAsync(GSTClientAddressExtension);

                _response.Result = _mapper.Map<GSTClientAddressExtensionDTO>(GSTClientAddressExtension);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetGSTClientAddressExtension", new { id = GSTClientAddressExtension.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/GSTClientAddressExtension/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTClientAddressExtension(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var GSTClientAddressExtension = await _dbGSTClientAddressExtension.GetAsync(u => u.Id == id);
                if (GSTClientAddressExtension == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbGSTClientAddressExtension.RemoveAsync(GSTClientAddressExtension);

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