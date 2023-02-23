using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class CollectionAndBalance
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }
        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public double? FeesAmount { get; set; }
        public double? PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime? AmountReceivedDate { get; set; }

    }
}
