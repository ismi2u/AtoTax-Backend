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
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="Admin")]
    public class GSTClientsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public GSTClientsController(IMapper mapper, AtoTaxDbContext context, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/GSTClients
        [HttpGet]
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClients([FromQuery] int pageSize = 0, int pageNumber = 1)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTClient> GSTClientsList = await _unitOfWork.GSTClients.GetAllAsync(null, pageSize: pageSize, pageNumber: pageNumber, arrIncludes);


                PaginationDTO pagination = new() { PageNumber = pageNumber, PageSize = pageSize };
                //send pagination details to response header
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<IEnumerable<GSTClientDTO>>(GSTClientsList);
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
        [ResponseCache(Duration = 30)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveGSTClientsForDD([FromQuery] int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<GSTClient> GSTClientsList = await _unitOfWork.GSTClients.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);


                //PaginationDTO pagination = new() { PageNumber = pageNumber, PageSize = pageSize };
                ////send pagination details to response header
                //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.Result = _mapper.Map<IEnumerable<ActiveGSTClientsForDD>>(GSTClientsList);
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
        // GET: api/GSTClients/5
        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTClient(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTClient GSTClient = await _unitOfWork.GSTClients.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTClientDTO>(GSTClient);
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

        // PUT: api/GSTClients/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTClient(Guid id, GSTClientUpdateDTO gstClientUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = gstClientUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "GSTClient modelstate invalid" };
                return Ok(_response);
            }

            try
            {
                if (id == Guid.Empty || !(id == gstClientUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = gstClientUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update GSTClient failed" };
                    return Ok(_response);
                }


                var oldgstclient = await _unitOfWork.GSTClients.GetAsync(u => u.Id == id, tracked: false);

                if (oldgstclient == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = gstClientUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTClient data is Null" };
                    return Ok(_response);
                }

                var gstClient = _mapper.Map<GSTClient>(gstClientUpdateDTO);

                //// dont update the GSTIN number which is the Identity of the GST Client
                gstClient.GSTIN = oldgstclient.GSTIN;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                gstClient.CreatedDate = oldgstclient.CreatedDate;

                await _unitOfWork.GSTClients.UpdateAsync(gstClient);



                //Client Fee Map table update check

                var ListOfServiceCategories = await _unitOfWork.ServiceCategories.GetAllAsync();
                foreach (var serviceCategory in ListOfServiceCategories)
                {
                    var existingClientFee = await _unitOfWork.ClientFeeMaps.GetAsync(u => u.ServiceCategoryId == serviceCategory.Id && u.GSTClientId == oldgstclient.Id, tracked: false);
                    if (existingClientFee == null)
                    {
                        ClientFeeMap clientFeeMap = new ClientFeeMap();

                        clientFeeMap.GSTClientId = gstClient.Id;
                        clientFeeMap.ServiceCategoryId = serviceCategory.Id;
                        clientFeeMap.DefaultCharge = serviceCategory.FixedCharge;
                        clientFeeMap.CreatedDate = DateTime.UtcNow;
                        clientFeeMap.LastModifiedDate = DateTime.UtcNow;

                        await _unitOfWork.ClientFeeMaps.CreateAsync(clientFeeMap);
                    }

                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = gstClientUpdateDTO;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GST Client updated";
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

        // POST: api/GSTClients
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTClient(GSTClientCreateDTO gstClientCreateDTO)
        {
            try
            {

                if (await _unitOfWork.GSTClients.GetAsync(u => u.GSTIN == gstClientCreateDTO.GSTIN) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = gstClientCreateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTIN should be unique" };
                    return Ok(_response);
                }
                if (await _unitOfWork.GSTClients.GetAsync(u => u.ProprietorName == gstClientCreateDTO.ProprietorName) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = gstClientCreateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTClient Propreitor Name already exists" };
                    return Ok(_response);
                }
                var gstClient = _mapper.Map<GSTClient>(gstClientCreateDTO);
                gstClient.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.GSTClients.CreateAsync(gstClient);

                var ListOfServiceCategories = await _unitOfWork.ServiceCategories.GetAllAsync();
                foreach (var serviceCategory in ListOfServiceCategories)
                {
                    ClientFeeMap clientFeeMap = new ClientFeeMap();

                    clientFeeMap.GSTClientId = gstClient.Id;
                    clientFeeMap.ServiceCategoryId = serviceCategory.Id;
                    clientFeeMap.DefaultCharge = serviceCategory.FixedCharge;
                    clientFeeMap.CreatedDate = DateTime.UtcNow;
                    clientFeeMap.LastModifiedDate = DateTime.UtcNow;

                    await _unitOfWork.ClientFeeMaps.CreateAsync(clientFeeMap);
                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<GSTClientDTO>(gstClient);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New GST Client created";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetGSTClient", new { id = gstClient.Id }, _response);
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

        // DELETE: api/GSTClients/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTClient(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTClient Id not found" };
                    return Ok(_response);
                }
                var gstClient = await _unitOfWork.GSTClients.GetAsync(u => u.Id == id);
                if (gstClient == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTClient not found" };
                    return Ok(_response);
                }

                await _unitOfWork.GSTClients.RemoveAsync(gstClient);

                var ListClientFeeMaps = await _unitOfWork.ClientFeeMaps.GetAllAsync(u => u.GSTClientId == id);
                foreach (var clientFeeMap in ListClientFeeMaps)
                {
                    await _unitOfWork.ClientFeeMaps.RemoveAsync(clientFeeMap);
                }

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = gstClient;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTClient deleted";
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
