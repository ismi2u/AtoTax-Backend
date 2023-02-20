
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTFilingTypeDTO
    {
        public int Id { get; set; }
        public string? FilingType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }
    }

    public class ActiveGSTFilingTypeForDD
    {
        public int Id { get; set; }
        public string? FilingType { get; set; }
     }

    public class GSTFilingTypeCreateDTO
    {
        [Required]
        public string? FilingType { get; set; }
        [Required]
        public int StatusId { get; set; }
    }

    public class GSTFilingTypeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FilingType { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
