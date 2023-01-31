using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtoTax.Domain.Entities
{
    public class ClientFeeCharge
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GSTClientId { get; set; }
        public double GSTMonthlySubmission { get; set; }
        public double GSTAmendment { get; set; }
        public double GSTAnnualReturnFiling { get; set; }
        public double GSTNoticeService { get; set; }

    }
}
