using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class ServiceChargeUpdateHistory
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("GSTClient")]
        public Guid GSTClientId { get; set; }
        public virtual GSTClient GSTClient { get; set; }
        public DateTime AmendedDate { get; set; }


        [Required]
        [ForeignKey("ReturnFrequencyType")]
        public int ReturnFrequencyTypeId { get; set; }
        public virtual ReturnFrequencyType ReturnFrequencyType { get; set; }

        public double PreviousRate { get; set; }
        public double NewRate { get; set; }



    }
}
