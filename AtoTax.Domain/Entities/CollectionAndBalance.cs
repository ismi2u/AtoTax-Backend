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

        [ForeignKey("Frequency")]
        public int FrequencyId { get; set; }
        public virtual Frequency Frequency { get; set; }

        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public double FeesAmount { get; set; }
        public double? AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public bool? IsInvoiceBillsRecvd { get; set; }
        public bool? IsReturnFiled { get; set; }
        public bool? IsMixedWithNILFiling { get; set; }
        public bool? IsNilFiling { get; set; }
        public bool? GSTR1 { get; set; }
        public bool? GSTR3B { get; set; }
        public bool? NILGSTR1 { get; set; }
        public bool? NIL3B { get; set; }
        public bool? GSTR9 { get; set; }
        public bool? GSTR9C { get; set; }
        public bool? GSTR10 { get; set; }

    }
}
