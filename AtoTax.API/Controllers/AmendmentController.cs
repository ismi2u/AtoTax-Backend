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
    public class AmendmentController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IAmendmentRepository _dbAmendment;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public AmendmentController(IAmendmentRepository dbAmendment, IMapper mapper, AtoTaxDbContext context)
        {
            _dbAmendment = dbAmendment;
            _mapper = mapper;
            this._response= new();
            _context = context;
        }

        // GET: api/Amendments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendments()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<Amendment> AmendmentsList = await _dbAmendment.GetAllAsync(null, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<AmendmentDTO>>(AmendmentsList);
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

        // GET: api/Amendments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmendment(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                Amendment Amendment = await _dbAmendment.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<AmendmentDTO>(Amendment);
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

       

        // POST: api/Amendments
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateAmendment(AmendmentCreateDTO AmendmentCreateDTO)
        {
            try
            {

                if (await _dbAmendment.GetAsync(u => u.AmendTypeId == AmendmentCreateDTO.AmendTypeId
                && u.GSTClientId == AmendmentCreateDTO.GSTClientId) != null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Record already exists for Amendment Type and GST Client" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
               
                var Amendment = _mapper.Map<Amendment>(AmendmentCreateDTO);
                Amendment.CreatedDate= DateTime.UtcNow;
                await _dbAmendment.CreateAsync(Amendment);

                _response.Result = _mapper.Map<AmendmentDTO>(Amendment);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetAmendment", new { id = Amendment.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/Amendments/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteAmendment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var Amendment = await _dbAmendment.GetAsync(u => u.Id == id);
                if (Amendment == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbAmendment.RemoveAsync(Amendment);

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