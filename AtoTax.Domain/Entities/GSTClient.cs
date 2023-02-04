using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class GSTClient
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ProprietorName { get; set; }
        [Required]
        public string GSTIN { get; set; }
        public string? ContactName { get; set; }
        public string? GSTUserName { get; set; }
        public string? GSTUserPassword { get; set; }
        [Required]
        public DateTime GSTRegDate { get; set; }
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

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status{ get; set; }



    }
}
