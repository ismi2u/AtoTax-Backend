using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class Employee
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
        [ForeignKey("EmpJobRole")]
        public int EmpJobRoleId { get; set; }
        public virtual EmpJobRole EmpJobRole { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
