using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class AccountLedger
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    
        public double? IncomeAmount { get; set; }
        public double? ExpenseAmount { get; set; }

        public bool? IsGSTClientPaid { get; set; }
        [Required]
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        [Required]
        public string? TransactionReferenceNo{ get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public string? TransactionRecordedBy { get; set; }

        public string? Comments { get; set; }

    }
}
