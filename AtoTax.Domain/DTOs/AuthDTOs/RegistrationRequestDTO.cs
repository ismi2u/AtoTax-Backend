﻿namespace AtoTax.Domain.DTOs.AuthDTOs
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Guid? EmployeeId { get; set; }
        public string Password { get; set; }
    }
}