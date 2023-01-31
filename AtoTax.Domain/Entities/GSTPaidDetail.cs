using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AtoTax.Domain.Entities
{
    public class GSTPaidDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? GSTClientID { get; set; }
        public string? PaidMonth { get; set; }
        public int PaidYear { get; set; }
        public double GSTAmount { get; set; }
        public int PaymentTypeId { get; set; }

    }
}
