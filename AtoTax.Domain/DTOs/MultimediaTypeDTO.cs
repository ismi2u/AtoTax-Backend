using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class MultimediaTypeDTO
    {

        public int Id { get; set; }
        public string Media { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }

    public class ActiveMultimediaTypesForDD
    {
        public int Id { get; set; }
        public string? MediaAndDesc { get; set; }
    }
    public class MultimediaTypeCreateDTO
    {
        [Required]
        public string Media { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StatusId { get; set; }

    }

    public class MultimediaTypeUpdateDTO
    {

        public int Id { get; set; }
        [Required]
        public string Media { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StatusId { get; set; }

    }
}
