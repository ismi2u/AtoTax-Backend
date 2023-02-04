using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTPaidDetailDTO
    {

        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }
        public string? PaymentDueMonth { get; set; }
        public int PaymentDueYear { get; set; }
        public double Amount { get; set; }
        public int ServiceCategoryId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime? SettledDate { get; set; }
        public bool? IsPending { get; set; }

    }

    public class GSTPaidDetailCreateDTO
    {
        public string? GSTClientID { get; set; }
        public string? PaymentDueMonth { get; set; }
        public int PaymentDueYear { get; set; }
        public double Amount { get; set; }
        public int ServiceCategoryId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime? SettledDate { get; set; }
        public bool? IsPending { get; set; }

    }

    public class GSTPaidDetailUpdateDTO
    {

        public Guid Id { get; set; }
        public string? GSTClientID { get; set; }
        public string? PaymentDueMonth { get; set; }
        public int PaymentDueYear { get; set; }
        public double Amount { get; set; }
        public int ServiceCategoryId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime? SettledDate { get; set; }
        public bool? IsPending { get; set; }

    }
}
