using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class MediaTypeDTO
    {

        public int Id { get; set; }
        public string Media { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int StatusId { get; set; }
        public StatusDTO Status { get; set; }

    }

    public class MediaTypeCreateDTO
    {
        [Required]
        public string Media { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StatusId { get; set; }

    }

    public class MediaTypeUpdateDTO
    {

        public int Id { get; set; }
        [Required]
        public string Media { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StatusId { get; set; }

    }
}
