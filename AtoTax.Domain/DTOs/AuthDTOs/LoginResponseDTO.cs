using AtoTax.Domain.Entities;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }

        //string user
        public LocalUser User { get; set; }
    }
}