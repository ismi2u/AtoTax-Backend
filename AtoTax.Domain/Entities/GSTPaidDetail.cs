using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AtoTax.Domain.Entities
{
    public class GSTPaidDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }

        [Required]
        public string? PaymentDueMonth { get; set; }
        [Required]
        public int PaymentDueYear { get; set; }
        [Required]
        public double Amount { get; set; }

        [Required]
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        [Required]
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public DateTime? SettledDate { get; set; }

        public bool? IsPending { get; set; }


    }
}
