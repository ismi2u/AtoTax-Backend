using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTBillAndFeeCollectionDTO
    {

        public Guid Id { get; set; }
        public Guid GSTClientID { get; set; }
        public GSTClientDTO GSTClient { get; set; }
        public string DueMonth { get; set; }
        public int Year { get; set; }
        public int GSTFilingTypeId { get; set; }
        public GSTFilingTypeDTO GSTFilingType { get; set; }
        public int ReceivedBy { get; set; }
        public EmployeeDTO ReceivedByEmployee { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int MultimediaTypeId { get; set; }
        public int FiledBy { get; set; }
        public EmployeeDTO FiledByEmployee { get; set; }
        public DateTime? FiledDate { get; set; }
        public bool IsBillsReceived { get; set; }
        public bool IsFiled { get; set; }
        public double FeesAmount { get; set; }
        public double FeesPaidAmt { get; set; }
        public double Balance { get; set; }
        public bool ReceivedAckEmailSent { get; set; }
        public bool GSTFiledAckEmailSent { get; set; }
        public bool ReceivedAckSMSSent { get; set; }
        public bool GSTFiledAckSMSSent { get; set; }

    }

    public class GSTBillAndFeeCollectionCreateDTO
    {
        [Required]
        public Guid GSTClientID { get; set; }
        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int GSTFilingTypeId { get; set; }
        public int ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int MultimediaTypeId { get; set; }
        public int FiledBy { get; set; }
        public DateTime? FiledDate { get; set; }
        public bool IsBillsReceived { get; set; }
        public bool IsFiled { get; set; }
        public double FeesAmount { get; set; }
        public double FeesPaidAmt { get; set; }
        public double Balance { get; set; }
        public bool ReceivedAckEmailSent { get; set; }
        public bool GSTFiledAckEmailSent { get; set; }
        public bool ReceivedAckSMSSent { get; set; }
        public bool GSTFiledAckSMSSent { get; set; }

    }

    public class GSTBillAndFeeCollectionUpdateDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid GSTClientID { get; set; }
        [Required]
        public string DueMonth { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int GSTFilingTypeId { get; set; }
        public int ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int MultimediaTypeId { get; set; }
        public int FiledBy { get; set; }
        public DateTime? FiledDate { get; set; }
        public bool IsBillsReceived { get; set; }
        public bool IsFiled { get; set; }
        public double FeesAmount { get; set; }
        public double FeesPaidAmt { get; set; }
        public double Balance { get; set; }
        public bool ReceivedAckEmailSent { get; set; }
        public bool GSTFiledAckEmailSent { get; set; }
        public bool ReceivedAckSMSSent { get; set; }
        public bool GSTFiledAckSMSSent { get; set; }

    }

}
