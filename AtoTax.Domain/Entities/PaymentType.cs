using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class PaymentType
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public Guid Id { get; set; }
        public string? PaymentMethod { get; set; }

        public int StatusTypeId { get; set; }

    }
}
