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
using Azure;
using System.Net;
using AtoTax.API.Repository.Interfaces;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IStatusRepository _dbStatusTbl;
        private readonly IMapper _mapper;


        public StatusController(AtoTaxDbContext context, IMapper mapper, IStatusRepository dbStatusTbl)
        {
            _dbStatusTbl = dbStatusTbl;
            _mapper = mapper;
            this._response = new();
        }

        // GET: api/Status
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult<APIResponse>> GetStatus()
        {
            try
            {
                IEnumerable<Status> statuses = await _dbStatusTbl.GetAllAsync();

                _response.Result = _mapper.Map<IEnumerable<Status>>(statuses);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);


        }
    }
}