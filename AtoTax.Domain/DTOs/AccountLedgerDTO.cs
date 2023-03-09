


using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class AccountLedgerDTO
    {
        public Guid Id { get; set; }
        public double? IncomeAmount { get; set; }
        public double? ExpenseAmount { get; set; }
        public bool? IsGSTClientPaid { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public int PaymentTypeId { get; set; }
        public  PaymentTypeDTO PaymentType { get; set; }
        public string? TransactionReferenceNo { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? TransactionRecordedBy { get; set; }

        public string? Comments { get; set; }

    }

    public class AccountLedgerCreateDTO
    {
        public double? IncomeAmount { get; set; }
        public double? ExpenseAmount { get; set; }
        public int PaymentTypeId { get; set; }
        public string? TransactionReferenceNo { get; set; }
        public string? Comments { get; set; }

    }

}
