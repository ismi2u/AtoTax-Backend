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
using static AtoTax.Domain.DTOs.ServiceChargeUpdateHistoryCreateDTO;
using AtoTax.API.GenericRepository;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="User")]
    public class ServiceChargeUpdateHistoryController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ServiceChargeUpdateHistoryController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ServiceChargeUpdateHistory
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceChargeUpdateHistory()
        {
            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                IEnumerable<ServiceChargeUpdateHistory> ServiceChargeUpdateHistoryList = await _unitOfWork.ServiceChargeUpdateHistories.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ServiceChargeUpdateHistoryDTO>>(ServiceChargeUpdateHistoryList);
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

        // GET: api/ServiceChargeUpdateHistory/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceChargeUpdateHistory(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ServiceChargeUpdateHistory ServiceChargeUpdateHistory = await _unitOfWork.ServiceChargeUpdateHistories.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ServiceChargeUpdateHistoryDTO>(ServiceChargeUpdateHistory);
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
       
    }
}
