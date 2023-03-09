using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AtoTax.Domain.Entities
{
    public class GSTBillAndFeeCollection
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }

        public string DueMonth { get; set; }
        public int DueYear { get; set; }


        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        [ForeignKey("GSTFilingType")]
        public int? GSTFilingTypeId { get; set; }
        public virtual GSTFilingType GSTFilingType { get; set; }

        public string? ReceivedBy { get; set; }

        public DateTime? ReceivedDate { get; set; }

        [ForeignKey("MultimediaType")]
        public int MultimediaTypeId { get; set; }
        public virtual MultimediaType MultimediaType { get; set; }
        public string? FiledBy { get; set; }
        public DateTime? FiledDate { get; set; }
        public bool? IsBillsReceived { get; set; }
        public bool? IsFiled { get; set; }

        public bool? ReceivedAckEmailSent { get; set; }
        public bool? GSTFiledAckEmailSent { get; set; }
        public bool? ReceivedAckSMSSent { get; set; }
        public bool? GSTFiledAckSMSSent { get; set; }

    }
}
