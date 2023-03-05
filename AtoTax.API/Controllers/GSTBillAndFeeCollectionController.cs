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
using AtoTax.API.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(Roles="User")]
    public class GSTBillAndFeeCollectionController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GSTBillAndFeeCollectionController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            this._response = new();
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: api/GSTBillAndFeeCollection
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<GSTBillAndFeeCollection> GSTBillAndFeeCollectionList = await _unitOfWork.GSTBillAndFeeCollections.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<GSTBillAndFeeCollectionDTO>>(GSTBillAndFeeCollectionList);
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

        // GET: api/GSTBillAndFeeCollection/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetGSTBillAndFeeCollection(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                GSTBillAndFeeCollection GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
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

        // PUT: api/GSTBillAndFeeCollection/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateGSTBillAndFeeCollection(Guid id, GSTBillAndFeeCollectionUpdateDTO GSTBillAndFeeCollectionUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection modelstate invalid" };
                return Ok(_response);
            }


            try
            {
                if (id == Guid.Empty || !(id == GSTBillAndFeeCollectionUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "Update GSTBillAndFeeCollection failed" };
                    return Ok(_response);
                }

               

                var oldGSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id, tracked: false);

                if (oldGSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Result = GSTBillAndFeeCollectionUpdateDTO;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection data is Null" };
                    return Ok(_response);
                }

                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionUpdateDTO);

                //// dont update the FilingType number which is the Identity of the FilingType
                string loggedUserName = User.Identity.Name;
                var loggedUserEmpId = _userManager.FindByNameAsync(loggedUserName).Result.EmployeeId;
                
                GSTBillAndFeeCollection.FiledBy = loggedUserEmpId;
                GSTBillAndFeeCollection.ReceivedBy = oldGSTBillAndFeeCollection.ReceivedBy;
                GSTBillAndFeeCollection.ReceivedDate = oldGSTBillAndFeeCollection.ReceivedDate;
                GSTBillAndFeeCollection.FiledDate = oldGSTBillAndFeeCollection.ReceivedDate;
                GSTBillAndFeeCollection.DueMonth = oldGSTBillAndFeeCollection.DueMonth;
                GSTBillAndFeeCollection.DueYear = oldGSTBillAndFeeCollection.DueYear;

                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //GSTBillAndFeeCollection.CreatedDate = oldGSTBillAndFeeCollection.CreatedDate;

                await _unitOfWork.GSTBillAndFeeCollections.UpdateAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTBillAndFeeCollection;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTBillAndFeeCollection updated";
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

        // POST: api/GSTBillAndFeeCollection
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateGSTBillAndFeeCollection(GSTBillAndFeeCollectionCreateDTO GSTBillAndFeeCollectionCreateDTO)
        {
            string loggedUserName = User.Identity.Name;
            var loggedUserEmpId = _userManager.FindByNameAsync(loggedUserName).Result.EmployeeId;
            GSTBillAndFeeCollectionCreateDTO.ReceivedBy = loggedUserEmpId;


            try
            {

                //if (await _dbGSTBillAndFeeCollection.GetAsync(u => u.FilingType == GSTBillAndFeeCollectionCreateDTO.FilingType) != null)
                //{
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return Ok(_response);
                //}

                var GSTBillAndFeeCollection = _mapper.Map<GSTBillAndFeeCollection>(GSTBillAndFeeCollectionCreateDTO);
                //GSTBillAndFeeCollection.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.GSTBillAndFeeCollections.CreateAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<GSTBillAndFeeCollectionDTO>(GSTBillAndFeeCollection);
                _response.IsSuccess = true;
                _response.SuccessMessage = "New GSTBillAndFeeCollection created";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetGSTBillAndFeeCollection", new { id = GSTBillAndFeeCollection.Id }, _response);
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



        // DELETE: api/GSTBillAndFeeCollection/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteGSTBillAndFeeCollection(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection Id not found" };
                    return Ok(_response);
                }
                var GSTBillAndFeeCollection = await _unitOfWork.GSTBillAndFeeCollections.GetAsync(u => u.Id == id);
                if (GSTBillAndFeeCollection == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Result = null;
                    _response.IsSuccess = false;
                    _response.SuccessMessage = null;
                    _response.ErrorMessages = new List<string> { "GSTBillAndFeeCollection not found" };
                    return Ok(_response);
                }

                await _unitOfWork.GSTBillAndFeeCollections.RemoveAsync(GSTBillAndFeeCollection);

                await _unitOfWork.CompleteAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = GSTBillAndFeeCollection;
                _response.IsSuccess = true;
                _response.SuccessMessage = "GSTBillAndFeeCollection deleted";
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
