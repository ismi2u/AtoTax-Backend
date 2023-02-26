
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class AccountLedgerDTO
    {
        public Guid Id { get; set; }
        public Guid? GSTClientId { get; set; }
        public virtual GSTClientDTO GSTClient { get; set; } 

        public int DataEntryEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public double? IncomingAmount { get; set; }
        public double? ExpenseAmount { get; set; }

        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public string? Comments { get; set; }

    }

    public class AccountLedgerCreateDTO
    {
        [Required]
        public Guid? GSTClientId { get; set; }
        [Required]
        public int DataEntryEmployee { get; set; }
        public DateTime? Date { get; set; }
        public double? IncomingAmount { get; set; }
        public double? ExpenseAmount { get; set; }
        [Required]
        public int PaymentTypeId { get; set; }
        public string? Comments { get; set; }

    }

    public class AccountLedgerUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid? GSTClientId { get; set; }
        [Required]
        public int DataEntryEmployee { get; set; }
        public DateTime? Date { get; set; }
        public double? IncomingAmount { get; set; }
        public double? ExpenseAmount { get; set; }
        [Required]
        public int PaymentTypeId { get; set; }
        public string? Comments { get; set; }

    }
}
