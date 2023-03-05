using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class AccountLedger
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("GSTClient")]
        public Guid? GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }


        public string User { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public double? IncomingAmount { get; set; }
        public double? ExpenseAmount { get; set; }
        [Required]
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public string? Comments { get; set; }
        

    }
}
