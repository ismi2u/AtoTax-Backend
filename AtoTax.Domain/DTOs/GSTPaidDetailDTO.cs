using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class GSTPaidDetailDTO
    {

       public Guid Id { get; set; }
        public string? GSTClientID { get; set; }
        public string? PaidMonth { get; set; }
        public int PaidYear { get; set; }
        public double GSTAmount { get; set; }
        public int PaymentTypeId { get; set; }

    }
}
