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
using AtoTax.Domain.DTOs.AuthDTOs;
using Azure;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authorization;
using AtoTax.API.Authentication;
using Microsoft.AspNetCore.Identity;
using AtoTax.API.Repository.Repos;

namespace AtoTax.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUserRepository _userRepository;


        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            LoginResponseDTO loginResponse = await _userRepository.Login(model);

            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName or Password is incorrect");
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.SuccessMessage = "User Logged-in successfully";
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            return Ok(await _userRepository.Register(model));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO model)
        {
            return Ok(await _userRepository.ForgotPassword(model));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            return Ok(await _userRepository.ResetPassword(model));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            return Ok(await _userRepository.ChangePassword(model));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDTO model)
        {
            return Ok(await _userRepository.ConfirmEmail(model));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            return Ok(await _userRepository.DeleteUser(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDTO model)
        {
            return Ok(await _userRepository.UpdateUser(model));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> AssignRoles([FromBody] AssignRolesDTO model)
        {
            return Ok(await _userRepository.AssignRoles(model));
        }
        //#########################################################################################
        //#########################################################################################
        //#########################################################################################
        //#########################################################################################

        //private Task<ApplicationUser> GetCurrentUserAsync()
        //{
        //    return _userManager.GetUserAsync(HttpContext.User);
        //}

        [HttpGet]
        [ActionName("GetAllUsers")]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }


        [HttpGet]
        [ActionName("GetAllRoles")]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _userRepository.GetRoles());
        }

        
        [HttpGet]
        [ActionName("GetRolesforUser")]
       // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetRolesforUser(string id)
        {
            return Ok(await _userRepository.GetRolesforUser(id));
        }
    }
}
