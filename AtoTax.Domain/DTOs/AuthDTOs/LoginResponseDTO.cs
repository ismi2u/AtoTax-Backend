using AtoTax.Domain.Entities;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }

        public string Roles { get; set; }
        public UserDTO User { get; set; }
    }
}