
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTFilingTypeDTO
    {


        public int Id { get; set; }
        public string? FilingType { get; set; }

        public int StatusTypeId { get; set; }

    }
}
