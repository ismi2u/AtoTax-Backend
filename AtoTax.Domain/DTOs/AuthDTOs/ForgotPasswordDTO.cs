using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class ForgotPasswordDTO
    {
        public string? username { get; set; }
        public string? email { get; set; }

        
    }
}