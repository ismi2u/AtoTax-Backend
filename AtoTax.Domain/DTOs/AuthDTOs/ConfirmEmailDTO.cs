using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class ConfirmEmailDTO
    {
        public string? token { get; set; }
        public string? email { get; set; }
    }
}