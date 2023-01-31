using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class EmpJobRoleDTO
    {

       public Guid Id { get; set; }
        public string? JobRole { get; set; }
        public string? JobDescription { get; set; }
        public int StatusTypeId { get; set; }
    }
}
