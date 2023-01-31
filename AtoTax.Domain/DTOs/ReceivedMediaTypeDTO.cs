using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class ReceivedMediaTypeDTO
    {

        public int Id { get; set; }
        public string? Media { get; set; }
        public string? Description { get; set; }
        public int StatusTypeId { get; set; }

    }
}
