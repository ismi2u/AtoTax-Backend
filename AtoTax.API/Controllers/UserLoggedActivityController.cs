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
    public class UserLoggedActivityController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AtoTaxDbContext _context;

        public UserLoggedActivityController(IUnitOfWork unitOfWork, IMapper mapper, AtoTaxDbContext context)
        {
            _mapper = mapper;
            this._response= new();
            _context = context;
            _unitOfWork = unitOfWork;   
        }
        

        // GET: api/UserLoggedActivity
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUserLoggedActivity()
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();

            try
            {
                IEnumerable<UserLoggedActivity> UserLoggedActivityList = await _unitOfWork.UserLoggedActivities.GetAllAsync(null, 0, 0, arrIncludes);

                _response.Result = _mapper.Map<IEnumerable<UserLoggedActivityDTO>>(UserLoggedActivityList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.ErrorMessages= new List<string>() { ex.ToString()};
            }
            return Ok(_response);
        }

        // GET: api/UserLoggedActivity/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUserLoggedActivity(Guid id)
        {

            List<string> includelist = new List<string>();
            includelist.Add("Status");
            string[] arrIncludes = includelist.ToArray();
            try
            {
                UserLoggedActivity UserLoggedActivity = await _unitOfWork.UserLoggedActivities.GetAsync(u => u.Id == id, false, arrIncludes);


                _response.Result = _mapper.Map<UserLoggedActivityDTO>(UserLoggedActivity);
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

        // PUT: api/UserLoggedActivity/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateUserLoggedActivity(Guid id, UserLoggedActivityUpdateDTO UserLoggedActivityUpdateDTO)
        {
            try
            {
                if (id == Guid.Empty || !(id == UserLoggedActivityUpdateDTO.Id))
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var oldUserLoggedActivity = await _unitOfWork.UserLoggedActivities.GetAsync(u => u.Id == id, tracked: false);

                if (oldUserLoggedActivity == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_response);
                }

                var UserLoggedActivity = _mapper.Map<UserLoggedActivity>(UserLoggedActivityUpdateDTO);

                ////// dont update the DOB number which is the Identity of the UserLoggedActivity
                //UserLoggedActivity.DOB = oldUserLoggedActivity.DOB;
               

                ////// dont update the below field as they are not part of updateDTO  and hence will become null
                //UserLoggedActivity.CreatedDate = oldUserLoggedActivity.CreatedDate;

                //await _dbUserLoggedActivity.UpdateAsync(UserLoggedActivity);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return Ok(_response);
                 }

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = UserLoggedActivity;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        // POST: api/UserLoggedActivity
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateUserLoggedActivity(UserLoggedActivityCreateDTO UserLoggedActivityCreateDTO)
        {
            try
            {

                //if (await _dbUserLoggedActivity.GetAsync(u => u.FirstName == UserLoggedActivityCreateDTO.FirstName 
                //                                && u.LastName == UserLoggedActivityCreateDTO.LastName
                //                                && u.DOB == UserLoggedActivityCreateDTO.DOB) != null)
                //{
                //    _response.ErrorMessages = new List<string>() { "UserLoggedActivity already Exists"};
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    return Ok(_response);
                //}
                var UserLoggedActivity = _mapper.Map<UserLoggedActivity>(UserLoggedActivityCreateDTO);
                //UserLoggedActivity.CreatedDate= DateTime.UtcNow;
                await _unitOfWork.UserLoggedActivities.CreateAsync(UserLoggedActivity);

                await _unitOfWork.CompleteAsync();
                _response.Result = _mapper.Map<UserLoggedActivityDTO>(UserLoggedActivity);
                _response.IsSuccess = true;
                _response.SuccessMessage = "UserLoggedActivity recorded";
                _response.ErrorMessages = null;

                return CreatedAtAction("GetUserLoggedActivity", new { id = UserLoggedActivity.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        // DELETE: api/UserLoggedActivity/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteUserLoggedActivity(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var UserLoggedActivity = await _unitOfWork.UserLoggedActivities.GetAsync(u => u.Id == id);
                if (UserLoggedActivity == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _unitOfWork.UserLoggedActivities.RemoveAsync(UserLoggedActivity);

                await _unitOfWork.CompleteAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
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
