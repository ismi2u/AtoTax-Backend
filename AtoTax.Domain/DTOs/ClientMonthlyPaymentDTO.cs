using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AtoTax.Domain.Entities;

namespace AtoTax.Domain.DTOs
{

    public class ClientMonthlyPaymentDTO
    {
        public Guid Id { get; set; }
        public Guid? GSTClientId { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public string? DueMonth { get; set; }
        public int? DueYear { get; set; }
        public int ReturnFrequencyTypeId { get; set; }
        public ReturnFrequencyTypeDTO ReturnFrequencyType { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentTypeDTO PaymentType { get; set; }
        public string? PaymentReferenceNumber { get; set; }
        public double? ReceivedAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionRecordedBy { get; set; }
        public string? Comments { get; set; }

    }
    public class ClientMonthlyPaymentCreateDTO
    {

        [Required]
        public Guid? GSTClientId { get; set; }
        [Required]
        public string? DueMonth { get; set; }
        [Required]
        public int? DueYear { get; set; }
        [Required]
        public int ReturnFrequencyTypeId { get; set; }
        [Required]
        public int PaymentTypeId { get; set; }
        [Required]
        public string? PaymentReferenceNumber { get; set; }
        [Required]
        public double? ReceivedAmount { get; set; }

        public string? Comments { get; set; }

    }


}
