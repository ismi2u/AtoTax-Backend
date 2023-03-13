using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AtoTax.Domain.Entities
{
    public class ReturnFrequencyType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ReturnFreqType { get; set; }

        public string Description { get; set; }
        public double FixedCharge { get; set; }
        public double? PreviousCharge { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
    public enum EFrequency
    {
        MonthlyReturn = 1,
        NilGSTR = 2,
        QuaterlyReturn = 3,
        AnnualReturn = 4,
        FinalReturn = 5
    }
}
