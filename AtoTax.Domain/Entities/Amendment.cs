using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class Amendment
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }

        [Required]
        [ForeignKey("AmendType")]
        public int AmendTypeId { get; set; }
        public virtual AmendType AmendType { get; set; }

        public string ARN { get; set; }
        
        public DateTime? SumittedDate { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("ApprovalStatusType")]
        public int ApprovalStatusTypeId { get; set; }
        public virtual ApprovalStatusType ApprovalStatusType { get; set; }

    }
}
