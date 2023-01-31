using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class MediaType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public Guid Id { get; set; }
        public string? Media { get; set; }
        public string? Description { get; set; }
        public int StatusTypeId { get; set; }

    }
}
