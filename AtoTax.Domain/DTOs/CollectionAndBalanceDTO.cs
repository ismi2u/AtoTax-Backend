using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class CollectionAndBalanceDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int? GSTClientId { get; set; }
        public string? DueMonth { get; set; }
        public int? Year { get; set; }
        public double? FeesAmount { get; set; }
        public double? PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime? AmtReceivedDate { get; set; }

    }

    public class CollectionAndBalanceCreateDTO
    {
        [Required]
        public int? GSTClientId { get; set; }
        [Required]
        public string? DueMonth { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public double? FeesAmount { get; set; }
        public double? PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime? AmtReceivedDate { get; set; }

    }

    public class CollectionAndBalanceUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int? GSTClientId { get; set; }
        [Required]
        public string? DueMonth { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public double? FeesAmount { get; set; }
        public double? PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime? AmtReceivedDate { get; set; }

    }
}
