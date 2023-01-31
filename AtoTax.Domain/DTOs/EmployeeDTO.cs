﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class EmployeeDTO
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string? Email { get; set; }
        public string? ConcactNo { get; set; }
        public int? EmpJobRoleId { get; set; }
        public int StatusTypeId { get; set; }

    }
}
