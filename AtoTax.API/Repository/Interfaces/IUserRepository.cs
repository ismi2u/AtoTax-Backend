﻿using AtoTax.API.Authentication;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IUserRepository
    {

        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);

        Task<APIResponse> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task<APIResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<APIResponse> ConfirmEmail(ConfirmEmailDTO confirmEmailDTO);

        Task<APIResponse> ChangePassword(ChangePasswordDTO changePasswordDTO);
    }
}
