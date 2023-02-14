using AtoTax.API.Authentication;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IUserRepository
    {

        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);

    }
}
