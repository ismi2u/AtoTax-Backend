using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class ChangePasswordDTO
    { 
        public string? Email { get; set; }
        public string? Oldpassword { get; set; }
        public string? NewPassword { get; set; }

    }
}