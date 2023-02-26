﻿using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class ResetPasswordDTO
    {
        public string? Email { get; set; }
        public string? Token { get; set; }

        public string? NewPassword { get; set; }
    }
}