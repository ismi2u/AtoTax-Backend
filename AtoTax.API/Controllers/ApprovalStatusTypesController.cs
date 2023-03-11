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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles="User")]
    public class ApprovalStatusTypesController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IApprovalStatusTypeRepository _dbApprovalStatusTbl;
        private readonly IMapper _mapper;


        public ApprovalStatusTypesController(AtoTaxDbContext context, IMapper mapper, IApprovalStatusTypeRepository dbApprovalStatusTbl)
        {
            _dbApprovalStatusTbl = dbApprovalStatusTbl;
            _mapper = mapper;
            this._response = new();
        }

        // GET: api/ApprovalStatusType
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 3600)]
        public async Task<ActionResult<APIResponse>> GetApprovalStatusTypesForDD()
        {
            try
            {
                IEnumerable<ApprovalStatusType> approvalStatusTypes = await _dbApprovalStatusTbl.GetAllAsync();

                _response.Result = _mapper.Map<IEnumerable<ApprovalStatusTypeDTO>>(approvalStatusTypes);
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