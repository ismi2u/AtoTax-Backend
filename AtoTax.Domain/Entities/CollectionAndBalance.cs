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
        [Required]
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public double? FeesAmount { get; set; }
        public double AmountPaid { get; set; }
        public bool? IsGSTBillReceived { get; set; }
        public bool? IsGSTFiled { get; set; }
        public double CurrentBalance { get; set; }
        

    }
}
