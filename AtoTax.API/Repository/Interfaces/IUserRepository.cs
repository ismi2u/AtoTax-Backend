using AtoTax.API.Authentication;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IUserRepository
    {

        bool IsUniqueUser(string username);

        
        Task<APIResponse> GetUsers();
        Task<APIResponse> GetRoles();
        Task<APIResponse> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<APIResponse> DeleteUser(DeleteUserDTO deleteUserDTO);
        Task<APIResponse> UpdateUser(UpdateUserDTO updateUserDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<APIResponse> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task<APIResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<APIResponse> ConfirmEmail(ConfirmEmailDTO confirmEmailDTO);

        Task<APIResponse> ChangePassword(ChangePasswordDTO changePasswordDTO);

        Task<APIResponse> AssignRoles (AssignRolesDTO assignRolesDTO);
    }
}
