using AtoTax.Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class ClientMonthlyPayment
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }
        [Required]
        public string? DueMonth { get; set; }
        [Required]
        public int? DueYear { get; set; }

        [Required]
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        [Required]
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        [Required]
        public string? PaymentReferenceNumber { get; set; }

        [Required]
        //received amount 
        public double? ReceivedAmount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string? TransactionRecordedBy { get; set; }

        public string? Comments { get; set; }

    }
}
