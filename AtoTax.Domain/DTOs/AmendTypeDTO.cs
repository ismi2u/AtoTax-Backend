
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class AmendTypeDTO
    {
        public int Id { get; set; }
        public string AmendTypeName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int StatusId { get; set; }
    }

    public class AmendTypeCreateDTO
    {
        [Required]
        public string AmendTypeName { get; set; }

        [Required]
        public int StatusId { get; set; }
    }

    public class AmendTypeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AmendTypeName { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
