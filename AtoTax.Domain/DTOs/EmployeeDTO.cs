using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class EmployeeDTO
    {

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string? Email { get; set; }
        public string? ConcactNo { get; set; }
        public int? EmpJobRoleId { get; set; }
        public EmpJobRoleDTO EmpJobRole { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }

    public class ActiveEmployeesForDD
    {
        public int Id { get; set; }
        public string? EmpFullName { get; set; }
    }
    public class EmployeeCreateDTO
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public DateTime? DOJ { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? ConcactNo { get; set; }
        [Required]
        public int? EmpJobRoleId { get; set; }
        [Required]
        public int StatusId { get; set; }

    }

    public class EmployeeUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? ConcactNo { get; set; }
        [Required]
        public int? EmpJobRoleId { get; set; }
        [Required]
        public int StatusId { get; set; }

    }

    public class ActiveEmployeeForDD
    {
        public Guid Id { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
