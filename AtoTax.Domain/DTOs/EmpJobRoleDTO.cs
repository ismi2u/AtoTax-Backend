using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class EmpJobRoleDTO
    {
        public int Id { get; set; }
        public string? JobRole { get; set; }
        public string? JobDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }
    }


    public class ActiveEmpJobRolesForDD
    {
        public int Id { get; set; }
        public string? JobRoleANdDesc { get; set; }
    }

        public class EmpJobRoleCreateDTO
    {
        [Required]
        public string? JobRole { get; set; }
        public string? JobDescription { get; set; }
        [Required]
        public int StatusId { get; set; }
    }

    public class EmpJobRoleUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? JobRole { get; set; }
        public string? JobDescription { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
