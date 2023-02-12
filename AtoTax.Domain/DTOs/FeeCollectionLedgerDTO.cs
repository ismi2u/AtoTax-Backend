
using AtoTax.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class FeeCollectionLedgerDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public string DueMonth { get; set; }
        public int Year { get; set; }
        public double FeesAmount { get; set; }
        public double PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime AmtReceivedDate { get; set; }

    }

    public class FeeCollectionLedgerCreateDTO
    {
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int Year { get; set; }
        public double FeesAmount { get; set; }
        public double PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime AmtReceivedDate { get; set; }


    }

    public class FeeCollectionLedgerUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid GSTClientId { get; set; }
        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int Year { get; set; }
        public double FeesAmount { get; set; }
        public double PreviousBalance { get; set; }
        public double AmountPaid { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime AmtReceivedDate { get; set; }

    }
}
