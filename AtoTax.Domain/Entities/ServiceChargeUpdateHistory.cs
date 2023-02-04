using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class ServiceChargeUpdateHistory
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int GSTClientId { get; set; }
        public DateTime AmendedDate { get; set; }
        public int ServiceCategoryId { get; set; }
        public double PreviousRate { get; set; }
        public double NewRate { get; set; }



    }
}
