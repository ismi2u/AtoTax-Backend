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
   // [Authorize(Roles="User")]
    public class ClientFeeMapsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ClientFeeMapsController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/ClientFeeMaps
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeMaps()
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ClientFeeMap> ClientFeeMapsList = await _unitOfWork.ClientFeeMaps.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ClientFeeMapDTO>>(ClientFeeMapsList);
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

        // GET: api/ClientFeeMaps/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetClientFeeMap(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("GSTClient");
            includelist.Add("ServiceCategory");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ClientFeeMap ClientFeeMap = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ClientFeeMapDTO>(ClientFeeMap);
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

        // PUT: api/ClientFeeMaps/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateClientFeeMap(Guid id, ClientFeeMapUpdateDTO ClientFeeMapUpdateDTO)
        {

            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = ClientFeeMapUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "ClientFeeMap modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == Guid.Empty || !(id == ClientFeeMapUpdateDTO.Id) || ClientFeeMapUpdateDTO.GSTClientId == Guid.Empty || ClientFeeMapUpdateDTO.ServiceCategoryId == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ClientFeeMapUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update ClientFeeMap failed" };
                    return Ok(_response);
                }


                var oldClientFeeMap = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.Id == id, tracked: false);

                if (oldClientFeeMap == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = ClientFeeMapUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "ClientFeeMap data is Null" };
                    return Ok(_response);
                }

                var ClientFeeMap = _mapper.Map<ClientFeeMap>(ClientFeeMapUpdateDTO);

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ClientFeeMap.CreatedDate = oldClientFeeMap.CreatedDate;
                await _unitOfWork.ClientFeeMaps.UpdateAsync(ClientFeeMap);

                //create a new record in ServiceChargeUpdateHistory table to capture the update history
                ServiceChargeUpdateHistory serviceChargeUpdateHistory = _mapper.Map<ServiceChargeUpdateHistory>(ClientFeeMapUpdateDTO);
                serviceChargeUpdateHistory.AmendedDate = DateTime.UtcNow;
                serviceChargeUpdateHistory.PreviousRate = oldClientFeeMap.DefaultCharge;
                serviceChargeUpdateHistory.NewRate = ClientFeeMapUpdateDTO.DefaultCharge;

                await _unitOfWork.ServiceChargeUpdateHistories.CreateAsync(serviceChargeUpdateHistory);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = ClientFeeMap;
                _response.IsSuccess = true;
                _response.SuccessMessage = "ClientFeeMap updated";
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
