using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTBillAndFeeCollectionDTO
    {

        public Guid Id { get; set; }
        public Guid GSTClientID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int GSTFilingTypeId { get; set; }
        public int ReceivedBy { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int MediaTypeId { get; set; }
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
