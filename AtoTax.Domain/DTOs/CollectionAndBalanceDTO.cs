using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class CollectionAndBalanceDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int? GSTClientId { get; set; }
        public string? DueMonth { get; set; }
        public int? Year { get; set; }
        public double? FeesAmount { get; set; }
        public double? PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime? AmtReceivedDate { get; set; }

    }
}
