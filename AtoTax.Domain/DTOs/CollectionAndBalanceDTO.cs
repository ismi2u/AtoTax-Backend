using AtoTax.Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class CollectionAndBalanceDTO
    {
        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public FrequencyDTO Frequency { get; set; }
        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public double? FeesAmount { get; set; }
        public double? AmountPaid { get; set; }
        public bool IsGSTBillReceived { get; set; }
        public bool IsGSTFiled { get; set; }
        public double CurrentBalance { get; set; }

    }

    //used in ClientMonthlyPayments 
    
    public class ClientApplicableReturnsDTO
    {
        public Guid GSTClientId { get; set; }

        public List<ClientFrequencyForDD> Frequencies { get; set; }

    }

    
}
