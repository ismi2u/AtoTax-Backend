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
        public int ServiceCategoryId { get; set; }
        public ServiceCategoryDTO ServiceCategory { get; set; }
        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public double? FeesAmount { get; set; }
        public double? AmountPaid { get; set; }
        public bool IsGSTBillReceived { get; set; }
        public bool IsGSTFiled { get; set; }

    }

    //used in ClientMonthlyPayments
    public class ClientGSTRelatedMonthandYearDTO
    {
        public Guid GSTClientId { get; set; }

        public List<string> ListMonths { get; set; }
        public List<int> ListYears { get; set; }
    }

    //public class CollectionAndBalanceCreateDTO
    //{
    //    [Required]
    //    public Guid GSTClientId { get; set; }
    //    [Required]
    //    public int ServiceCategoryId { get; set; }
    //    [Required]
    //    public string? DueMonth { get; set; }
    //    [Required]
    //    public int? DueYear { get; set; }
    //    public double? FeesAmount { get; set; }
    //    public double? AmountPaid { get; set; }
    //    public bool? IsGSTBillReceived { get; set; }
    //    public bool? IsGSTFiled { get; set; }

    //}

    //public class CollectionAndBalanceUpdateDTO
    //{[Required]
    //    public Guid Id { get; set; }
    //    [Required]
    //    public Guid GSTClientId { get; set; }
    //    [Required]
    //    public int ServiceCategoryId { get; set; }
    //    [Required]
    //    public string? DueMonth { get; set; }
    //    [Required]
    //    public int? DueYear { get; set; }
    //    public double? FeesAmount { get; set; }
    //    public double? AmountPaid { get; set; }
    //    public bool? IsGSTBillReceived { get; set; }
    //    public bool? IsGSTFiled { get; set; }

    //}
}
