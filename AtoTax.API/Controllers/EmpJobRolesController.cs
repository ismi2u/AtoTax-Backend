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
    [Authorize(Roles="Admin")]
    public class EmpJobRoleController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public EmpJobRoleController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork= unitOfWork;
        }

        // GET: api/EmpJobRole
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmpJobRole()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<EmpJobRole> EmpJobRoleList = await _unitOfWork.EmpJobRoles.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<EmpJobRoleDTO>>(EmpJobRoleList);
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetActiveJobRolesForDD()
        {
            try
            {
                IEnumerable<EmpJobRole> EmpJobRoleList = await _unitOfWork.EmpJobRoles.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ActiveEmpJobRoleForDD>>(EmpJobRoleList);
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

        // GET: api/EmpJobRole/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmpJobRole(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                EmpJobRole EmpJobRole = await _unitOfWork.EmpJobRoles.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<EmpJobRoleDTO>(EmpJobRole);
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

        // PUT: api/EmpJobRole/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateEmpJobRole(int id, EmpJobRoleUpdateDTO EmpJobRoleUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == EmpJobRoleUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldEmpJobRole = await _unitOfWork.EmpJobRoles.GetAsync(u => u.Id == id, tracked: false);

                if (oldEmpJobRole == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var EmpJobRole = _mapper.Map<EmpJobRole>(EmpJobRoleUpdateDTO);

                //// dont update the JobRole number which is the Identity of the GST Client
                EmpJobRole.JobRole = oldEmpJobRole.JobRole;

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                EmpJobRole.CreatedDate = oldEmpJobRole.CreatedDate;

                await _unitOfWork.EmpJobRoles.UpdateAsync(EmpJobRole);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = EmpJobRole;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/EmpJobRole
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateEmpJobRole(EmpJobRoleCreateDTO EmpJobRoleCreateDTO)
        {
            try
            {

                if (await _unitOfWork.EmpJobRoles.GetAsync(u => u.JobRole == EmpJobRoleCreateDTO.JobRole) != null)
                {
                    _response.ErrorMessages = new List<string>() { "Job Role already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var EmpJobRole = _mapper.Map<EmpJobRole>(EmpJobRoleCreateDTO);
                EmpJobRole.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.EmpJobRoles.CreateAsync(EmpJobRole);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<EmpJobRoleDTO>(EmpJobRole);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetEmpJobRole", new { id = EmpJobRole.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/EmpJobRole/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteEmpJobRole(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var EmpJobRole = await _unitOfWork.EmpJobRoles.GetAsync(u => u.Id == id);
                if (EmpJobRole == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.EmpJobRoles.RemoveAsync(EmpJobRole);

                await _unitOfWork.CompleteAsync();
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
