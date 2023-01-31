using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class GSTClient
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProprietorName { get; set; }
        public string? GSTIN { get; set; }
        public string? ContactName { get; set; }
        public string? GSTUserName { get; set; }
        public string? GSTUserPassword { get; set; }
        public DateTime? GSTRegDate { get; set; }
        public DateTime? GSTSurrenderedDate { get; set; }
        public DateTime? GSTRelievedDate { get; set; }
        public double? GSTAnnualTurnOver { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactEmailId { get; set; }
        public string? GSTEmailId { get; set; }
        public string? GSTEmailPassword { get; set; }
        public string? GSTRecoveryEmailId { get; set; }
        public string? GSTRecoveryEmailPassword { get; set; }
        public string? EWAYBillUserName { get; set; }
        public string? EWAYBillPassword { get; set; }
        public string? RackFileNo { get; set; }
        public string? TallyDataFilePath { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int StatusTypeId { get; set; }


    }
}
