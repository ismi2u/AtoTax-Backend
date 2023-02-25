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
    [Authorize(Roles = "Admin")]
    public class ServiceCategoryController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public ServiceCategoryController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
           
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ServiceCategorys
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceCategories()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<ServiceCategory> ServiceCategorysList = await _unitOfWork.ServiceCategories.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<ServiceCategoryDTO>>(ServiceCategorysList);
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
        public async Task<ActionResult<APIResponse>> GetActiveServiceCategoriesForDD()
        {
            try
            {
                IEnumerable<ServiceCategory> ServiceCategorysList = await _unitOfWork.ServiceCategories.GetAllAsync(a => a.StatusId == (int)EStatus.active, 0, 0);

                _response.Result = _mapper.Map<IEnumerable<ActiveServiceCategoryForDD>>(ServiceCategorysList);
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

        // GET: api/ServiceCategorys/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceCategory(int id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                ServiceCategory ServiceCategory = await _unitOfWork.ServiceCategories.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<ServiceCategoryDTO>(ServiceCategory);
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

        // PUT: api/ServiceCategorys/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateServiceCategory(int id, ServiceCategoryUpdateDTO ServiceCategoryUpdateDTO)
        {
            try
            {
                if (id == 0 || !(id == ServiceCategoryUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldServiceCategory = await _unitOfWork.ServiceCategories.GetAsync(u => u.Id == id, tracked: false);

                if (oldServiceCategory == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                var ServiceCategory = _mapper.Map<ServiceCategory>(ServiceCategoryUpdateDTO);

                //// dont update the below field as they are not part of updateDTO  and hence will become null
                ServiceCategory.CreatedDate = oldServiceCategory.CreatedDate;
                ServiceCategory.PreviousCharge = oldServiceCategory.FixedCharge;

                await _unitOfWork.ServiceCategories.UpdateAsync(ServiceCategory);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return _response;
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = ServiceCategory;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // POST: api/ServiceCategorys
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateServiceCategory(ServiceCategoryCreateDTO ServiceCategoryCreateDTO)
        {
            try
            {

                if (await _unitOfWork.ServiceCategories.GetAsync(u => u.ServiceName == ServiceCategoryCreateDTO.ServiceName) != null)
                {
                    _response.ErrorMessages = new List<string>() { "ServiceCategory already Exists"};
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var ServiceCategory = _mapper.Map<ServiceCategory>(ServiceCategoryCreateDTO);
                ServiceCategory.PreviousCharge= ServiceCategoryCreateDTO.FixedCharge;
                await _unitOfWork.ServiceCategories.CreateAsync(ServiceCategory);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<ServiceCategoryDTO>(ServiceCategory);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtAction("GetServiceCategory", new { id = ServiceCategory.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // DELETE: api/ServiceCategorys/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteServiceCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var ServiceCategory = await _unitOfWork.ServiceCategories.GetAsync(u => u.Id == id);
                if (ServiceCategory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.ServiceCategories.RemoveAsync(ServiceCategory);

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
